using AElf.Sdk.CSharp.State;
using System;
namespace ForGreen
{
    /// <summary>
    /// The state class of the contract, it inherits from the AElf.Sdk.CSharp.State.ContractState type. 
    /// </summary>
    public class ForGreenContractState : ContractState
    {
        public Int32State EventIds { get; set; }
        public Int32State TokenIds { get; set; }
        public Int32State BidIds { get; set; }
        public Int32State EventTokenIds { get; set; }
        public Int32State TokenBidIds { get; set; }
        public MappedState<int, string> EventUris { get; set; }
        public MappedState<int, string> TokenUris { get; set; }
        public MappedState<int, string> BidUris { get; set; }
        public MappedState<int, EventToken> AllEventTokens { get; set; }
        public MappedState<int, TokenBid> AllTokenBids { get; set; }
        public MappedState<int, EventToken> SearchedEventTokens { get; set; }
        public MappedState<int, TokenBid> SearchedTokenBids { get; set; }
    }
}