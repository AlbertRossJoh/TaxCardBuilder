# TaxCardBuilder
This project is intended to create an easy to use api for building danish tax reports. This api is built on top of filehelpers for creating and parsing the fixed format files.

Most if not all variables are written in danish, this is deliberate because of the nature of the domain. This will make it easier to refer to documentation regarding what variable are supposed to be.

Because the underlying library is inherently synchronous there are no async methods yet, this however might change if I choose to implement my own engine.
# Example
```csharp
var builder = new TaxFileBuilder();
builder.AddRecord1000(
    indberetterSeNummer: "12345678",
    isTest: true,
    systemUsage: SystemUsage.Eindkomst,
    indberetterType: IndberetterType.Virksomhed,
    hovedIndberetningsId: new ShortId())
    .AddRecord2001(
        virksomhedSE: "12345678", 
        ophørHosLSB: false);
var stream = builder.Build();
```
# ToDo
There is still a lot to be done which includes.
- Links to documentation on records.
- Validation of record order.
  - This is a work in progress
- Parsing receipts and other information from SKAT.
- Creating explicit types for CVR, CPR, Address.
- Make it into a nuget package.
