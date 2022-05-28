using AElf.Boilerplate.TestBase;
using AElf.Cryptography.ECDSA;

namespace DemeterGift
{
    public class DemeterGiftContractTestBase : DAppContractTestBase<DemeterGiftContractTestModule>
    {
        // You can get address of any contract via GetAddress method, for example:
        // internal Address DAppContractAddress => GetAddress(DAppSmartContractAddressNameProvider.StringName);

        internal DemeterGiftContractContainer.DemeterGiftContractStub GetDemeterGiftContractStub(ECKeyPair senderKeyPair)
        {
            return GetTester<DemeterGiftContractContainer.DemeterGiftContractStub>(DAppContractAddress, senderKeyPair);
        }
    }
}