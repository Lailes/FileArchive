using System;
using System.Collections.Generic;
using System.Linq;

namespace FileArchive.Models.Dummies
{
    public class FakeAppContext: IFileProvider
    {
        private IEnumerable<FileDetail> FileDetails => new FileDetail[] {
                    new(){FileName = "Cat.jpg", BytesCount = 10000, UploadDateTime = DateTime.Now, OwnerEmail = "Lutiaan@gmail.com"}, 
                    new() {FileName = "CuteCat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, OwnerEmail = "Lutiaan@gmail.com"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, OwnerEmail = "Lutiaan@gmail.com"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, OwnerEmail = "Lutiaan@gmail.com"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, OwnerEmail = "Lutiaan@gmail.com"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, OwnerEmail = "Lutiaan@gmail.com"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, OwnerEmail = "Lutiaan@gmail.com"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, OwnerEmail = "Lutiaan@gmail.com"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaatCuteCaaaaaaaaaaaaaatCuteCaaaaaaaaaaaaaatCuteCaaaaaaaaaaaaaatCuteCaaaaaaaaaaaaaatCuteCaaaaaaaaaaaaaatCuteCaaaaaaaaaaaaaatCuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, OwnerEmail = "Lutiaan@gmail.com"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, OwnerEmail = "Lutiaan@gmail.com"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, OwnerEmail = "Lutiaan@gmail.com"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, OwnerEmail = "Lutiaan@gmail.com"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, OwnerEmail = "Lutiaan@gmail.com"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, OwnerEmail = "Lutiaan@gmail.com"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, OwnerEmail = "Lutiaan@gmail.com"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, OwnerEmail = "Lutiaan@gmail.com"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, OwnerEmail = "Lutiaan@gmail.com"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, OwnerEmail = "Lutiaan@gmail.com"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, OwnerEmail = "Lutiaan@gmail.com"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, OwnerEmail = "Lutiaan@gmail.com"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, OwnerEmail = "Lutiaan@gmail.com"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, OwnerEmail = "Lutiaan@gmail.com"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, OwnerEmail = "Lutiaan@gmail.com"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, OwnerEmail = "Lutiaan@gmail.com"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, OwnerEmail = "Lutiaan@gmail.com"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, OwnerEmail = "Lutiaan@gmail.com"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, OwnerEmail = "Lutiaan@gmail.com"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, OwnerEmail = "Lutiaan@gmail.com"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, OwnerEmail = "Lutiaan@gmail.com"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaatCuteCaaaaaaaaaaaaaatCuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, OwnerEmail = "Lutiaan@gmail.com"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, OwnerEmail = "Lutiaan@gmail.com"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, OwnerEmail = "Lutiaan@gmail.com"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, OwnerEmail = "Lutiaan@gmail.com"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, OwnerEmail = "Lutiaan@gmail.com"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, OwnerEmail = "Lutiaan@gmail.com"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, OwnerEmail = "Lutiaan@gmail.com"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, OwnerEmail = "Lutiaan@gmail.com"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, OwnerEmail = "Lutiaan@gmail.com"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, OwnerEmail = "Lutiaan@gmail.com"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, OwnerEmail = "Lutiaan@gmail.com"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, OwnerEmail = "Lutiaan@gmail.com"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, OwnerEmail = "Lutiaan@gmail.com"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, OwnerEmail = "Lutiaan@gmail.com"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, OwnerEmail = "Lutiaan@gmail.com"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, OwnerEmail = "Lutiaan@gmail.com"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, OwnerEmail = "Lutiaan@gmail.com"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, OwnerEmail = "Lutiaan@gmail.com"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, OwnerEmail = "Lutiaan@gmail.com"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, OwnerEmail = "Lutiaan@gmail.com"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, OwnerEmail = "Lutiaan@gmail.com"}
        }.AsEnumerable();

        public IEnumerable<FileDetail> GetFileDetailsForName(string? name)
        {
            return FileDetails.Where(detail => detail.OwnerEmail == name);
        }
    }
}