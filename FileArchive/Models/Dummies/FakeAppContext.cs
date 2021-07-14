using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileArchive.Models.Dummies
{
    public class FakeAppContext: IFileProvider
    {
        public Task<IEnumerable<FileDetails>> GetFilesForUserAsync(string userName) =>
            Task.Run(() =>
            {
                return new FileDetails[] {
                    new(){FileName = "Cat.jpg", BytesCount = 10000, UploadDateTime = DateTime.Now}, 
                    new() {FileName = "CuteCat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today},
                }.AsEnumerable();
            });
    }
}