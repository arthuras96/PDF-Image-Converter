using PdfiumViewer;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;

namespace PDFImageConvert
{
    class Program
    {
		public static string projectDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;

		static void Main(string[] args)
        {
			string pathToSave = projectDir + @"\Samples\";
			string pathPDF = projectDir + @"\Samples\ENEM 2009.pdf";

			Converter converter = new Converter();
			converter.ConvertPDFToImage(pathPDF, pathToSave, 200, 25);

			List<string> imagesToConvert = new List<string>();
			string[] files = Directory.GetFiles(pathToSave);
			foreach (string file in files)
				if (file.Split('.')[file.Split('.').Length - 1].ToLower() == "jpg")
					imagesToConvert.Add(file);
			imagesToConvert.Sort();

			converter.ConvertImageToPDF(imagesToConvert, pathToSave + "ENEM 2009 reconvertido.pdf", 1000);
		}
	}
}
