module internal Types

type TaxRecord =
    | Record1000 = 1000
    | Record2001 = 2001
    | Record2101 = 2101
    | Record2111 = 2111
    | Record3101 = 3101
    | Record4101 = 4101
    | Record5000 = 5000
    | Record6000 = 6000
    | Record6001 = 6001
    | Record6002 = 6002
    | Record6003 = 6003
    | Record6004 = 6004
    | Record6005 = 6005
    | Record6102 = 6102
    | Record6202 = 6202
    | Record6111 = 6111
    | Record8001 = 8001
    | Record9999 = 9999
    
type Cardinality =
    | One
    | OneOrMore
    | ZeroOrOne
    | AnyAmount
    | ZeroToThree
    
type RecordNode = {
    children: Map<TaxRecord, RecordNode>
    allowedAmount: Cardinality
}

type record_data = {
    occurrences: int
}

let constructRecordNode n c =
    {
        children = Map.ofList c
        allowedAmount = n 
    }

let recordStructure =
    Map.ofList [
        TaxRecord.Record1000, constructRecordNode One [
            TaxRecord.Record2001, constructRecordNode OneOrMore [
                TaxRecord.Record2101, constructRecordNode AnyAmount [
                    TaxRecord.Record8001, constructRecordNode ZeroOrOne [];
                    TaxRecord.Record2111, constructRecordNode AnyAmount [];
                ];
                TaxRecord.Record3101, constructRecordNode AnyAmount [];
                TaxRecord.Record4101, constructRecordNode AnyAmount [];
                TaxRecord.Record5000, constructRecordNode OneOrMore [
                    TaxRecord.Record6000, constructRecordNode AnyAmount [
                        TaxRecord.Record8001, constructRecordNode ZeroOrOne [];
                        TaxRecord.Record6001, constructRecordNode AnyAmount [];
                        TaxRecord.Record6002, constructRecordNode AnyAmount [];
                        TaxRecord.Record6003, constructRecordNode AnyAmount [];
                        TaxRecord.Record6004, constructRecordNode AnyAmount [];
                        TaxRecord.Record6005, constructRecordNode AnyAmount [];
                        TaxRecord.Record6102, constructRecordNode ZeroToThree [];
                        TaxRecord.Record6202, constructRecordNode ZeroToThree [];
                        TaxRecord.Record6111, constructRecordNode AnyAmount [];
                        TaxRecord.Record6111, constructRecordNode AnyAmount [];
                    ]
                ];
            ]
        ];
        TaxRecord.Record9999, constructRecordNode One []]
