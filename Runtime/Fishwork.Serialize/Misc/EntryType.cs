namespace Fishwork.Serialize {

  public enum EntryType : byte {
    Invalid,
    
    Null,
    String,
    Integer,
    Float,
    Bool,
    
    StartOfNode,
    EndOfNode,
    
    StartOfArray,
    EndOfArray,
    
    InternalRef,
    ExternalRefByIndex,
    ExternalRefByGuid,
    ExternalRefByString,
  }

}
