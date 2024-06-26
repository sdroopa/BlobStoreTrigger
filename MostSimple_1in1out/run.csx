#r "Microsoft.WindowsAzure.Storage"            //For framework assemblies, add references by using the #r "AssemblyName" directive.

using Microsoft.WindowsAzure.Storage.Blob;
using System.IO;

/*
    * 
    * BLOB TRIGGER : New file(s) uploaded to blob path mentioned in 
    * input bindings function.json triggers this function, 
	* it does considers files added in sub directory under the blob path
	* which is set as a path in trigger
    *
    * @param myBlob : input blob container path which is mentioned in trigger
    * @blobFileName : New file name captured when added to myBlob path
    * @outputBlob : This is the output path of blob defined in function json 
    * @param log : log any information when succesful or exception
    *
*/
public static async void Run(CloudBlockBlob myBlob, string blobFileName, CloudBlockBlob outputBlob, ILogger log)
{
    log.LogInformation($"C# Blob trigger function Processed blob\n Name:{blobFileName} ");
  
    using (var stream = await myBlob.OpenReadAsync())
    {
       await  outputBlob.UploadFromStreamAsync(stream);
    }
	
	 
}
