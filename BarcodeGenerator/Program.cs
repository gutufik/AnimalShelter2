using System;
using IronBarCode;


namespace BarcodeGenerator
{
    public class Program
    {
        public static void Main()
        {
            GeneratedBarcode barcode = IronBarCode.BarcodeWriter.CreateBarcode("https://www.youtube.com/", BarcodeEncoding.QRCode);
            barcode.SaveAsPng("barcode.png");
        }
    }
}
