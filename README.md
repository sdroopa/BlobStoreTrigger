# AzureFunction

- [Introduction](#introduction)
- [Trigger Type](#trigger-type) 
- [Blob Storage Trigger](#blob-storage-trigger)
* [MostSimple_1in1out](#MostSimple_1in1out) 

## Introduction

## Trigger Type

## Blob Storage Trigger

### MostSimple_1in1out
This is the most simple example which demonstartes the blob trigger with just few lines of code and easy bindings.
This can be first step to understand azure function's blob storage type of trigger.

Step1: This is how the structure of blob container looks.
![Blob Container Structure](../main/BlobStoreTrigger/MostSimple_1in1out/imagesstep1_blobdirectory.png?raw=true)
|:--:| 
| *Blob Container Structure*|

I have added one dummy.readme file in each of the above folder to retain. This is only to retain folder, emply folder gets deleted automatically.
![Blob Directory](../main/BlobStoreTrigger/MostSimple_1in1out/imagesstep1_blobdir_dummyfile.png?raw=true)
|:--:| 
| *Blob Directory*|
 
Step2: Go to Code+Test section inside new function. Select run.csx from drop down highlighted and add run.csx code
Select function.json from drop down highlighted and add function.json code.
Both the code are uploaded in path "AzureFunction\BlobStorageTrigger\CodeExamples\MostSimple_1in1out".

This code creates blob trigger which also acts as a trigger and monitors the input path mentioned. 
The output path is the destination to copy the files in blob.
![Add Code](../main/BlobStoreTrigger/MostSimple_1in1out/imagesstep2_AddCode.png?raw=true)
|:--:| 
| *Add Code*|
  
Step3: Compile the code by clicking on "Save" menu. This will be enabled when we add/update changes in code.Resolve the compilation errors if tehre are any until compilation is successful.
![Compile](../main/BlobStoreTrigger/MostSimple_1in1out/imagesstep3_compilation.png?raw=true)
|:--:| 
| *Compile*|

Step4: Time to add input file. In real case, the files would be pushed by some other source like IOT hub, some other azure functions,web apps etc which would be sending the desired input datat to this input monitored blob directory.
To verify this real case, we will upload the file manually to the input blob directory.
![Upload Input File](../main/BlobStoreTrigger/MostSimple_1in1out/imagesstep4_InputFile.png?raw=true)
|:--:| 
| *Upload Input File*|

Step5: Check the Azure function console. This will print any log information added and also if there are any error occurred while executing any steps of azure function.
![Console Log](../main/BlobStoreTrigger/MostSimple_1in1out/imagesstep5_ConsoleLogInfo.png?raw=true)
|:--:| 
| *Console Log*|

Step6: Lets verify the output directory mentioned, where we expect file to be copied. Quick verify by validating the size and time of copy.
![Output Dir](../main/BlobStoreTrigger/MostSimple_1in1out/imagesstep6_Output.png?raw=true)
|:--:| 
| *Output Dir*|

Important Note: While azure function is active, if files are pushed after some good amount of minutes/hours/days, azure function takes time to execute. 
This could be due to selection of serverless(model) infratrcture plan while creating an azure function.
This consumption plan follows concept of cold start. This plan adds instances on demand and removes instances of the functions dynamically,
which indicates that when our function is triggered due to a new file added, there might not be any immediate instance allotted to handle this request.
This means there will be a short delay(did not measure accurately everytime..in random cases found 2-3 minutes) when this function will start executing and hence starts copying to destination directory.
