using AElf.Sdk.CSharp.State;

namespace DemeterGift
{
    /// <summary>
    /// The state class of the contract, it inherits from the AElf.Sdk.CSharp.State.ContractState type. 
    /// </summary>
    public class DemeterGiftContractState : ContractState
    {
        public Int32State EventIds { get; set; }
        public Int32State TokenIds { get; set; }
        public MappedState<int, string> EventUris { get; set; }
        public MappedState<int, string> TokenUris { get; set; } 
        public MappedState<int, string[2]> AllEventTokens { get; set; }
    }
}