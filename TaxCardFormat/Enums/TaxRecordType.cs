using TaxCardFormat.RecordInterfaces.IRecord;
using TaxCardFormat.Records;

namespace TaxCardFormat.Enums;

public enum TaxRecordType
{
    Record1000 = 1000,
    Record2001 = 2001,
    Record2101 = 2101,
    Record3101 = 3101,
    Record4101 = 4101,
    Record5000 = 5000,
    Record6000 = 6000,
    Record6001 = 6001,
    Record6002 = 6002,
    Record6003 = 6003,
    Record6004 = 6004,
    Record6005 = 6005,
    Record6102 = 6102,
    Record6111 = 6111,
    Record6202 = 6202,
    Record8001 = 8001,
    Record9999 = 9999,
}

public static class TaxRecordTypeExtensions
{
    public static TaxRecordType ToTaxRecordType(this TaxRecord taxRecord) => taxRecord switch
    {
        Record1000 => TaxRecordType.Record1000,
        Record2001<object> => TaxRecordType.Record2001,
        Record2101<object> => TaxRecordType.Record2101,
        Record3101<object> => TaxRecordType.Record3101,
        Record4101<object> => TaxRecordType.Record4101,
        Record5000<object> => TaxRecordType.Record5000,
        Record6000<object> => TaxRecordType.Record6000,
        Record6001<object> => TaxRecordType.Record6001,
        Record6002<object> => TaxRecordType.Record6002,
        Record6003<object> => TaxRecordType.Record6003,
        Record6004<object> => TaxRecordType.Record6004,
        Record6005<object> => TaxRecordType.Record6005,
        Record6102<object> => TaxRecordType.Record6102,
        Record6111<object> => TaxRecordType.Record6111,
        Record6202<object> => TaxRecordType.Record6202,
        Record8001<object> => TaxRecordType.Record8001,
        Record9999 => TaxRecordType.Record9999,
        _ => throw new ArgumentOutOfRangeException(nameof(taxRecord), taxRecord, null)
    };
}
