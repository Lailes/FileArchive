using System;
using System.Collections.Generic;
using System.Linq;

namespace FileArchive.Models.Dummies
{
    public class FakeAppContext: IFileProvider
    {
        public IEnumerable<FileDetail> FileDetails => new FileDetail[] {
                    new(){FileName = "Cat.jpg", BytesCount = 10000, UploadDateTime = DateTime.Now, Owner = "Auriel"}, 
                    new() {FileName = "CuteCat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, Owner = "Auriel"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, Owner = "Auriel"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, Owner = "Auriel"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, Owner = "Auriel"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, Owner = "Auriel"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, Owner = "Auriel"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, Owner = "Auriel"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaatCuteCaaaaaaaaaaaaaatCuteCaaaaaaaaaaaaaatCuteCaaaaaaaaaaaaaatCuteCaaaaaaaaaaaaaatCuteCaaaaaaaaaaaaaatCuteCaaaaaaaaaaaaaatCuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, Owner = "Auriel"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, Owner = "Auriel"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, Owner = "Auriel"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, Owner = "Auriel"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, Owner = "Auriel"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, Owner = "Auriel"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, Owner = "Auriel"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, Owner = "Auriel"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, Owner = "Auriel"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, Owner = "Auriel"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, Owner = "Auriel"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, Owner = "Auriel"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, Owner = "Auriel"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, Owner = "Auriel"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, Owner = "Auriel"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, Owner = "Auriel"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, Owner = "Auriel"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, Owner = "Auriel"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, Owner = "Auriel"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, Owner = "Auriel"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, Owner = "Auriel"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaatCuteCaaaaaaaaaaaaaatCuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, Owner = "Auriel"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, Owner = "Auriel"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, Owner = "Auriel"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, Owner = "Auriel"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, Owner = "Auriel"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, Owner = "Auriel"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, Owner = "Auriel"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, Owner = "Auriel"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, Owner = "Auriel"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, Owner = "Auriel"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, Owner = "Auriel"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, Owner = "Auriel"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, Owner = "Auriel"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, Owner = "Auriel"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, Owner = "Auriel"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, Owner = "Auriel"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, Owner = "Auriel"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, Owner = "Auriel"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, Owner = "Auriel"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, Owner = "Auriel"},
                    new() {FileName = "CuteCaaaaaaaaaaaaaat.jpg", BytesCount = 155212, UploadDateTime = DateTime.Today, Owner = "Auriel"}
        }.AsEnumerable();

    }
}