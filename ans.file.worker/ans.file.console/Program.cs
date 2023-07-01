// See https://aka.ms/new-console-template for more information


using ans.file.console;

string fileUrl = "https://example.com/example.pdf"; // Reemplaza con tu URL de archivo

FileDownloader fileDownloader = new();
byte[]? fileBytes = await fileDownloader.DownloadFileAsync(fileUrl);

if (fileBytes is not null)
{
    // El archivo se ha descargado correctamente
    // Puedes trabajar con el array de bytes como desees, por ejemplo, guardarlo en disco o enviarlo como respuesta HTTP

    // Ejemplo: Guardar el archivo en disco
    File.WriteAllBytes("archivo_descargado.pdf", fileBytes);

    // Ejemplo: guarda el archivo en memoria.
    string str = Convert.ToBase64String(fileBytes);

    
}

Console.ReadLine();