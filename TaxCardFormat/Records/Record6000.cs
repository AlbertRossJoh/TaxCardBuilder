using FileHelpers;
using TaxCardFormat.Enums;
using TaxCardFormat.RecordInterfaces.IRecord;

namespace TaxCardFormat.Records;

[FixedLengthRecord]
public class Record6000<TPrevious> : Record6XXXBase<TPrevious>, IRecord6000<TPrevious>
{ 
    public Record6000(): this(default) {}
    
    public Record6000(TPrevious? previousRecord) : base(previousRecord)
    {
        _previous = previousRecord;
    }
    
    [FieldFixedLength(12)]
    public string filler1 = "";

    [FieldFixedLength(10)]
    public string? CPR;

    [FieldFixedLength(8)]
    public string? CVR_SE;

    [FieldFixedLength(15)]
    [FieldAlign(AlignMode.Right, ' ')]
    public string? MedarbejderNr;

    [FieldFixedLength(27)]
    [FieldAlign(AlignMode.Right, ' ')]
    public string? TIN;

    [FieldFixedLength(2)]
    public string? TIN_landekode;

    [FieldFixedLength(4)]
    [FieldAlign(AlignMode.Right, '0')]
    public required int Indtaegtsart;

    [FieldFixedLength(10)]
    [FieldAlign(AlignMode.Right, ' ')]
    public string? ProduktionEndhedsNummer;
   
    public IRecord6000<TPrevious> AddRecord8001(DateTime foedselsdato, Koen koen, Landekoder landekoder, string  navn, string adresse,
        string postnummer, string postby)
    {
        var child = new Record8001<IRecord6000<TPrevious>>(this)
        {
            Lb_nr = Lb_nr++,
            Rec_nr = 8001,
            PersonFoedselsdato = foedselsdato,
            PersonKoen = (int)koen,
            PersonLand = landekoder.ToString("G"),
            PersonNavn = navn,
            PersonGadeAdresse = adresse,
            PersonPostnummer = postnummer,
            PersonPostby = postby,
        };
        Children.Add(child);
        return this;
   }
}
