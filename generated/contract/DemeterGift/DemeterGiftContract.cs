using AElf.Types;
using Google.Protobuf.WellKnownTypes;
using System;

namespace DemeterGift
{
    /// <summary>
    /// The C# implementation of the contract defined in demeter_gift_contract.proto that is located in the "protobuf"
    /// folder.
    /// Notice that it inherits from the protobuf generated code. 
    /// </summary>
    public class DemeterGiftContract : DemeterGiftContractContainer.DemeterGiftContractBase
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
        #region "Events"
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
        #endregion


        /// <summary>
        /// Tokens
        /// </summary>
        #region "Tokens"
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
        #endregion



        /// <summary>
        /// Event + Tokens
        /// </summary>
        #region "Event + Tokens"
        //Background
        public void setAllEventToken(int EventTokenID, int EventID, string TokenURI)
        {
            var togehter = new Google.Protobuf.Collections.MapField<int, string>();
            togehter[EventID] = TokenURI;
            State.AllEventTokens[EventTokenID] = new EventToken { EventID = EventID, TokenURI = TokenURI };
        }
        //inserting
        public override Int32Value InsertAllEventToken(InsertEventTokenInput input)
        {
            string tokenURI = input.TokenURI;
            string eventID = input.EventID;

            CreateToken(tokenURI);
            setAllEventToken(State.EventTokenIds.Value, int.Parse(eventID), tokenURI);
            State.EventTokenIds.Value = State.EventTokenIds.Value + 1;
            return new Int32Value { Value = State.TokenIds.Value };
        }

        //Searching
        public override SearchedList SearchAllTokenByEventID(StringValue eventID)
        {
            var searchedList = new SearchedList();

            for (int i = 0; i < State.EventTokenIds.Value; i++)
            {
                var EventToken = State.AllEventTokens[i];
                if (EventToken.EventID == int.Parse( eventID.Value))
                {
                    searchedList.Tokens.Add(EventToken.TokenURI);
                }
            }
      
            return searchedList;
        }


        #endregion


    }
}