using AElf.Types;
using Google.Protobuf.WellKnownTypes;
using System;

namespace ForGreen
{
    /// <summary>
    /// The C# implementation of the contract defined in forgreen_contract.proto that is located in the "protobuf"
    /// folder.
    /// Notice that it inherits from the protobuf generated code. 
    /// </summary>
    public class ForGreenContract : ForGreenContractContainer.ForGreenContractBase
    {


        /// <summary>
        /// The implementation of the Hello method. It takes no parameters and returns on of the custom data types
        /// defined in the protobuf definition file.
        /// </summary>
        /// <param name="input">Empty message (from Protobuf)</param>
        /// <returns>a HelloReturn</returns>
        public override StringValue Hello(Empty input)
        {
            return new StringValue { Value = "Hello World!" };
        }



        /// <summary>
        /// Events
        /// </summary>
        public override StringValue CreateEvent(StringValue input)
        {
            State.EventUris[State.EventIds.Value] = input.Value;
            State.EventIds.Value = State.EventIds.Value + 1;
            return new StringValue { Value = State.EventIds.Value.ToString() };
        }
        public override StringValue getTotalEvent(Empty input)
        {

            return new StringValue { Value = State.EventIds.Value.ToString() };
        }
        public override StringValue getOneEvent(StringValue input)
        {

            var currnetEvent = State.EventUris[int.Parse(input.Value)];

            return new StringValue { Value = currnetEvent };
        }



        /// <summary>
        /// Tokens
        /// </summary>
        public void CreateToken(string input) //Background
        {
            State.TokenUris[State.TokenIds.Value] = input;
            State.TokenIds.Value = State.TokenIds.Value + 1;
        }
        public override StringValue getTotalToken(Empty input)
        {

            return new StringValue { Value = State.TokenIds.Value.ToString() };
        }
        public override StringValue getOneToken(StringValue input)
        {

            var currnetToken = State.TokenUris[int.Parse(input.Value)];

            return new StringValue { Value = currnetToken };
        }




        /// <summary>
        /// Bids
        /// </summary>        
        public void CreateBid(string input) //Background
        {
            State.BidUris[State.BidIds.Value] = input;
            State.BidIds.Value = State.BidIds.Value + 1;
        }
        public override StringValue getTotalBid(Empty input)
        {

            return new StringValue { Value = State.BidIds.Value.ToString() };
        }
        public override StringValue getOneBid(StringValue input)
        {

            var currnetBid = State.BidUris[int.Parse(input.Value)];

            return new StringValue { Value = currnetBid };
        }




        /// <summary>
        /// Event + Tokens
        /// </summary>
        public void setAllEventToken(int EventTokenID, int EventID, string TokenURI)   //Background
        {
            var togehter = new Google.Protobuf.Collections.MapField<int, string>();
            togehter[EventID] = TokenURI;
            State.AllEventTokens[EventTokenID] = new EventToken { EventID = EventID, TokenID = State.TokenIds.Value - 1, TokenURI = TokenURI };
        }
        public override Int32Value InsertAllEventToken(InsertEventTokenInput input)  //inserting
        {
            string tokenURI = input.TokenURI;
            string eventID = input.EventID;

            CreateToken(tokenURI);//creating NFT
            setAllEventToken(State.EventTokenIds.Value, int.Parse(eventID), tokenURI);
            State.EventTokenIds.Value = State.EventTokenIds.Value + 1;
            return new Int32Value { Value = State.TokenIds.Value };
        }
        public override SearchedList SearchAllTokenByEventID(StringValue eventID)  //Searching
        {
            var searchedList = new SearchedList();
            for (int i = 0; i < State.EventTokenIds.Value; i++)
            {
                var EventToken = State.AllEventTokens[i];
                if (EventToken.EventID == int.Parse(eventID.Value))
                {
                    searchedList.TokenID.Add(EventToken.TokenID);
                    searchedList.Tokens.Add(EventToken.TokenURI);
                }
            }
            return searchedList;
        }
        public int getEventTokenID(int EventID, string TokenURI)
        {
            for (int i = 0; i < State.EventTokenIds.Value; i++)
            {
                var EventToken = State.AllEventTokens[i];
                if (EventToken.EventID == EventID && EventToken.TokenURI == TokenURI)
                {
                    return i;
                }
            }
            return 0;
        }




        /// <summary>
        /// Token + Bid
        /// </summary>    
        public void setAllTokenBid(int TokenBidID, int BidID, string BidURI) //Background
        {
            var togehter = new Google.Protobuf.Collections.MapField<int, string>();
            togehter[BidID] = BidURI;
            State.AllTokenBids[TokenBidID] = new TokenBid { TokenID = BidID, BidURI = BidURI };
        }
        public override Int32Value InsertAllTokenBid(InsertTokenBidInput input) //inserting
        {
            string bidURI = input.BidURI;
            int tokenID = input.TokenID;
            int eventID = input.EventID;
            int EventTokenID = getEventTokenID(eventID, State.TokenUris[tokenID]);
            string updatedURI = input.UpdatedURI;

            setAllEventToken(EventTokenID, eventID, updatedURI);

            State.TokenUris[tokenID] = updatedURI;

            CreateBid(bidURI);
            setAllTokenBid(State.TokenBidIds.Value, tokenID, bidURI);
            State.TokenBidIds.Value = State.TokenBidIds.Value + 1;
            return new Int32Value { Value = State.TokenIds.Value };
        }
        public override SearchedListBids SearchAllBidByTokenID(StringValue tokenID) //Searching
        {
            var searchedListbids = new SearchedListBids();
            for (int i = 0; i < State.TokenBidIds.Value; i++)
            {
                var TokenBid = State.AllTokenBids[i];
                if (TokenBid.TokenID == int.Parse(tokenID.Value))
                {
                    searchedListbids.Bids.Add(TokenBid.BidURI);
                }
            }
            return searchedListbids;
        }



        /// <summary>
        /// Reset
        /// </summary>    
        public override StringValue ResetAll(Empty empty)
        {
            for (int i = 0; i < State.EventIds.Value; i++) State.EventUris.Remove(i);
            for (int i = 0; i < State.TokenIds.Value; i++) State.TokenUris.Remove(i);
            for (int i = 0; i < State.BidIds.Value; i++) State.BidUris.Remove(i);
            for (int i = 0; i < State.EventTokenIds.Value; i++) State.AllEventTokens.Remove(i);
            for (int i = 0; i < State.TokenBidIds.Value; i++) State.AllTokenBids.Remove(i);
            State.EventIds.Value = 0;
            State.TokenIds.Value = 0;
            State.BidIds.Value = 0;
            State.EventTokenIds.Value = 0;
            State.TokenBidIds.Value = 0;

            return new StringValue { Value = "Done" };
        }

    }
}