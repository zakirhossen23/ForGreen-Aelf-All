using AElf.Types;
using Google.Protobuf.WellKnownTypes;

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
        public override StringValue CreateToken(StringValue input)
        {
            State.TokenUris[State.TokenIds.Value] = input.Value;
            State.TokenIds.Value = State.TokenIds.Value + 1;
            return new StringValue { Value = State.TokenIds.Value.ToString() };
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

    }
}