using AElf.Boilerplate.TestBase;
using AElf.Cryptography.ECDSA;

namespace ForGreen
{
    public class ForGreenContractTestBase : DAppContractTestBase<ForGreenContractTestModule>
    {
        // You can get address of any contract via GetAddress method, for example:
        // internal Address DAppContractAddress => GetAddress(DAppSmartContractAddressNameProvider.StringName);

        internal ForGreenContractContainer.ForGreenContractStub GetForGreenContractStub(ECKeyPair senderKeyPair)
        {
            return GetTester<ForGreenContractContainer.ForGreenContractStub>(DAppContractAddress, senderKeyPair);
        }
    }
}