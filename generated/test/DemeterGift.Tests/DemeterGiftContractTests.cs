using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AElf.ContractTestBase.ContractTestKit;
using AElf.Types;
using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;
using Shouldly;
using Xunit;

namespace DemeterGift
{
    public class DemeterGiftContractTests : DemeterGiftContractTestBase
    {
        //string MyDictionaryToJson(Dictionary<string, string> dict)
        //{
        //    var entries = dict.Select(d =>
        //        string.Format("\"{0}\": \"{1}\"", d.Key, d.Value));
        //    return "{" + string.Join(",", entries) + "}";
        //}

        //public async Task CreateEvent(string eventUri)
        //{
        //    var keyPair = SampleAccount.Accounts.First().KeyPair;
        //    var stub = GetDemeterGiftContractStub(keyPair);
        //    var input = new StringValue
        //    {
        //        Value = eventUri
        //    };
        //    var output = (await stub.CreateEvent.SendAsync(input)).Output;

        //}

        //public string createEventGather(string Title,string End_Date, string Goal, string Logo_Link, string Wallet)
        //{
        //    Dictionary<string, string> InputOBJ = new Dictionary<string, string>();
        //    InputOBJ.Add("Title", Title);
        //    InputOBJ.Add("End Date", End_Date);
        //    InputOBJ.Add("Goal", Goal);
        //    InputOBJ.Add("Logo Link", Logo_Link);
        //    InputOBJ.Add("Wallet", Wallet);
        //    return MyDictionaryToJson(InputOBJ);
        //}

        [Fact]
        public async Task TestCreateEvent()
        {
            //// Get a stub for testing.
            //var keyPair = SampleAccount.Accounts.First().KeyPair;
            //var stub = GetDemeterGiftContractStub(keyPair);

            ////Custom input for Create Event
            //var input = createEventGather("Event 1", "25/9/2022", "500", "https://google.com/favicon.ico", "ELF_xgFX3P8yT46kEGYZJyWCu9pvb4zUZ8FcoRzCybMY8TWvMuTHs_tDVV");
            //var input2 = createEventGather("Event 2", "25/9/2022", "500", "https://google.com/favicon.ico", "ELF_xgFX3P8yT46kEGYZJyWCu9pvb4zUZ8FcoRzCybMY8TWvMuTHs_tDVV");

            ////Creating Event
            //await CreateEvent(input);
            //await CreateEvent(input2);

            ////Getting all Events
            //var allEvent = (await stub.getTotalEvent.SendAsync(new Empty())).Output.ToString();
            //var stringValueTotal = StringValue.Parser.ParseJson(allEvent);

            ////Comapring
            //(int.Parse(stringValueTotal.Value)).ShouldBe(2);
            //System.Console.WriteLine(stringValueTotal.Value);

            
        }

        [Fact]
        public async Task TestgetOneEvent()
        {
           //await TestCreateEvent();

           // // Get a stub for testing.
           // var keyPair = SampleAccount.Accounts.First().KeyPair;
           // var stub = GetDemeterGiftContractStub(keyPair);
            

           // var OneEvent =StringValue.Parser.ParseJson( (await stub.getOneEvent.SendAsync(new StringValue { Value="0"})).Output.ToString());
        
           // System.Console.WriteLine(OneEvent.Value);
        }

        [Fact]
        public async Task TestCreatingToken()
        {
            //await TestCreateEvent();
            //// Get a stub for testing.
            //var keyPair = SampleAccount.Accounts.First().KeyPair;
            //var stub = GetDemeterGiftContractStub(keyPair);

            //var TokenID =  await stub.InsertAllEventToken.SendAsync(new InsertEventTokenInput { EventID="0",TokenURI="{\"Title\":\"NFT 1\"}"});


            //System.Console.WriteLine(TokenID);
        }

    }
}