using System;
using IronBarCode;
using System.IO;


namespace BarcodeGenerator
{
    public class Generator
    {
        public static void Main()
        {
            GeneratedBarcode barcode = IronBarCode.BarcodeWriter.CreateBarcode("https://www.youtube.com/", BarcodeEncoding.QRCode);
            barcode.SaveAsPng("barcode.png");
        }
        public static byte[] GenereteQR(string data, string path)
        {
            GeneratedBarcode barcode = IronBarCode.BarcodeWriter.CreateBarcode(data, BarcodeEncoding.QRCode);
            barcode.SaveAsPng(path);
            return File.ReadAllBytes(path);
        }
    }
}
