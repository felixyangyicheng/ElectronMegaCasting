using Blazored.Toast.Services;
using MegaSolution.WebAssembly.Contracts;
using MegaSolution.WebAssembly.Models;
using MegaSolution.WebAssembly.Static;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MegaSolution.WebAssembly.Pages.Artists
{
    public class CreateBase: ComponentBase
    {
        [Inject]
        public IArtistRepository _repo { get; set; }
  
        [Inject]
        public NavigationManager _navManager { get; set; }
        [Inject]

        public IToastService _toastService { get; set; }
        protected Artist Model = new Artist();
        protected IBrowserFile file;
        protected bool isSuccess = true;
        protected bool isInvalidFileType = false;
        protected string imageDataURL;
        protected string cvDataURL;

        protected Stream msFile;

        protected async Task CreateArtist()
        {
            isSuccess = await _repo.Create(Endpoints.ArtistEndpoint, Model);
            if (isSuccess)
            {
                _toastService.ShowSuccess("Profile d'artiste a été crée", "");
                BackToList();
            }
        }

        protected async Task HandleCreate()
        {
            if (!isInvalidFileType)
            {
                if (file != null)
                {
                    var ext = Path.GetExtension(file.Name);
                    var picId = Guid.NewGuid().ToString().Replace("-", "");
                    var cvId = Guid.NewGuid().ToString().Replace("-", "");

                    var picName = $"{picId}{ext}";
                    var cvName = $"{cvId}{ext}";


                    Model.ProfilePhoto = picName;
                    Model.CV = cvName;

                    var bufferImg = new byte[file.Size];
                    var bufferCv = new byte[file.Size];

                    await file.OpenReadStream().ReadAsync(bufferImg);
                    await file.OpenReadStream().ReadAsync(bufferCv);

                    Model.ProfilePhoto = Convert.ToBase64String(bufferImg);
                    Model.CV = Convert.ToBase64String(bufferCv);

                }

                isSuccess = await _repo.Create(Endpoints.ArtistEndpoint, Model);
                if (isSuccess)
                {
                    _toastService.ShowSuccess("Profile Créé", "");
                    BackToList();
                }
            }
        }

        protected async Task HandleFileSelection(InputFileChangeEventArgs e)
        {
            file = e.File;
            if (file != null)
            {
                var ext = Path.GetExtension(file.Name);
                if (ext.Contains("jpg") || ext.Contains("png") || ext.Contains("jpeg")|| ext.Contains("pdf"))
                {
                    msFile = file.OpenReadStream();

                    var resizedImageFile = await file.RequestImageFileAsync("image/png",
                100, 100);
                    var resizedCvFile = await file.RequestImageFileAsync("image/png",
                100, 100);

                    var bufferImg = new byte[resizedImageFile.Size];
                    var bufferCv = new byte[resizedCvFile.Size];

                    await resizedImageFile.OpenReadStream().ReadAsync(bufferImg);
                    await resizedCvFile.OpenReadStream().ReadAsync(bufferImg);


                    var imageBase64Data = Convert.ToBase64String(bufferImg);
                    var cvBase64Data = Convert.ToBase64String(bufferCv);

                    imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);
                    cvDataURL = string.Format("data:image/png;base64,{0}", cvBase64Data);
                    isInvalidFileType = false;
                }
                else
                {
                    isInvalidFileType = true;
                    imageDataURL = string.Empty;
                    cvDataURL = string.Empty;

                }
            }
            else
            {
                isInvalidFileType = false;
            }
        }
        protected void BackToList()
        {
            _navManager.NavigateTo("/artists/");
        }
    }
}
