using Lutron.Common.Enums;
using Lutron.Common.Exceptions;
using Lutron.Common.Models;
using NUnit.Framework;

namespace Lutron.CommandBuilder.Tests
{
    [TestFixture]
    public class EthernetCommandBuilderTests
    {
        [TestFixture]
        public class BuildSetIpAddressCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = EthernetCommandBuilder.Create()
                    .WithOperation(CommandOperation.Set)
                    .WithAction(EthernetCommandConfigurationNumber.IpAddress)
                    .WithIpAddress(new IpAddress("192.168.1.1"))
                    .BuildSetIpAddressCommand();

                Assert.AreEqual("#ETHERNET,0,192.168.1.1<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoIpAddress
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<ParameterNotProvided>(()
                        => EthernetCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithAction(EthernetCommandConfigurationNumber.IpAddress)
                            .BuildSetIpAddressCommand());

                    Assert.AreEqual("The parameter, ip address, is not provided",
                        exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => EthernetCommandBuilder.Create()
                            .WithAction(EthernetCommandConfigurationNumber.IpAddress)
                            .WithIpAddress(new IpAddress("192.168.1.1"))
                            .BuildSetIpAddressCommand());

                    Assert.AreEqual("The operation is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectOperationProvided>(()
                        => EthernetCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithAction(EthernetCommandConfigurationNumber.IpAddress)
                            .WithIpAddress(new IpAddress("192.168.1.1"))
                            .BuildSetIpAddressCommand());

                    Assert.AreEqual("The operation provided is incorrect. Expected # and not ?",
                        exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectActionNumber
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectActionNumberProvided>(()
                        => EthernetCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithAction(EthernetCommandConfigurationNumber.MulticastAddress)
                            .WithIpAddress(new IpAddress("192.168.1.1"))
                            .BuildSetIpAddressCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 0 and not 5",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildGetIpAddressCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = EthernetCommandBuilder.Create()
                    .WithOperation(CommandOperation.Get)
                    .WithAction(EthernetCommandConfigurationNumber.IpAddress)
                    .BuildGetIpAddressCommand();

                Assert.AreEqual("?ETHERNET,0<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => EthernetCommandBuilder.Create()
                            .WithAction(EthernetCommandConfigurationNumber.IpAddress)
                            .BuildGetIpAddressCommand());

                    Assert.AreEqual("The operation is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectOperationProvided>(()
                        => EthernetCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithAction(EthernetCommandConfigurationNumber.IpAddress)
                            .BuildGetIpAddressCommand());

                    Assert.AreEqual("The operation provided is incorrect. Expected ? and not #",
                        exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectActionNumber
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectActionNumberProvided>(()
                        => EthernetCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithAction(EthernetCommandConfigurationNumber.MulticastAddress)
                            .BuildGetIpAddressCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 0 and not 5",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildSetGatewayAddressCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = EthernetCommandBuilder.Create()
                    .WithOperation(CommandOperation.Set)
                    .WithAction(EthernetCommandConfigurationNumber.GatewayAddress)
                    .WithGatewayAddress(new IpAddress("192.168.1.1"))
                    .BuildSetGatewayAddressCommand();

                Assert.AreEqual("#ETHERNET,1,192.168.1.1<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoGatewayAddress
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<ParameterNotProvided>(()
                        => EthernetCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithAction(EthernetCommandConfigurationNumber.GatewayAddress)
                            .BuildSetGatewayAddressCommand());

                    Assert.AreEqual("The parameter, gateway address, is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => EthernetCommandBuilder.Create()
                            .WithAction(EthernetCommandConfigurationNumber.GatewayAddress)
                            .BuildSetGatewayAddressCommand());

                    Assert.AreEqual("The operation is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectOperationProvided>(()
                        => EthernetCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithAction(EthernetCommandConfigurationNumber.GatewayAddress)
                            .BuildSetGatewayAddressCommand());

                    Assert.AreEqual("The operation provided is incorrect. Expected # and not ?",
                        exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectActionNumber
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectActionNumberProvided>(()
                        => EthernetCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithAction(EthernetCommandConfigurationNumber.MulticastAddress)
                            .BuildSetGatewayAddressCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 1 and not 5",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildGetGatewayAddressCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = EthernetCommandBuilder.Create()
                    .WithOperation(CommandOperation.Get)
                    .WithAction(EthernetCommandConfigurationNumber.GatewayAddress)
                    .BuildGetGatewayAddressCommand();

                Assert.AreEqual("?ETHERNET,1<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => EthernetCommandBuilder.Create()
                            .WithAction(EthernetCommandConfigurationNumber.GatewayAddress)
                            .BuildGetGatewayAddressCommand());

                    Assert.AreEqual("The operation is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectOperationProvided>(()
                        => EthernetCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithAction(EthernetCommandConfigurationNumber.GatewayAddress)
                            .BuildGetGatewayAddressCommand());

                    Assert.AreEqual("The operation provided is incorrect. Expected ? and not #",
                        exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectActionNumber
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectActionNumberProvided>(()
                        => EthernetCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithAction(EthernetCommandConfigurationNumber.MulticastAddress)
                            .BuildGetGatewayAddressCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 1 and not 5",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildSetSubnetMaskCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = EthernetCommandBuilder.Create()
                    .WithOperation(CommandOperation.Set)
                    .WithAction(EthernetCommandConfigurationNumber.SubnetMask)
                    .WithSubnetMask(new IpAddress("192.168.1.1"))
                    .BuildSetSubnetMaskCommand();

                Assert.AreEqual("#ETHERNET,2,192.168.1.1<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoSubnetMask
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<ParameterNotProvided>(()
                        => EthernetCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithAction(EthernetCommandConfigurationNumber.SubnetMask)
                            .BuildSetSubnetMaskCommand());

                    Assert.AreEqual("The parameter, subnet mask, is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => EthernetCommandBuilder.Create()
                            .WithAction(EthernetCommandConfigurationNumber.SubnetMask)
                            .BuildSetSubnetMaskCommand());

                    Assert.AreEqual("The operation is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectOperationProvided>(()
                        => EthernetCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithAction(EthernetCommandConfigurationNumber.SubnetMask)
                            .BuildSetSubnetMaskCommand());

                    Assert.AreEqual("The operation provided is incorrect. Expected # and not ?",
                        exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectActionNumber
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectActionNumberProvided>(()
                        => EthernetCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithAction(EthernetCommandConfigurationNumber.MulticastAddress)
                            .BuildSetSubnetMaskCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 2 and not 5",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildGetSubnetMaskCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = EthernetCommandBuilder.Create()
                    .WithOperation(CommandOperation.Get)
                    .WithAction(EthernetCommandConfigurationNumber.SubnetMask)
                    .BuildGetSubnetMaskCommand();

                Assert.AreEqual("?ETHERNET,2<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => EthernetCommandBuilder.Create()
                            .WithAction(EthernetCommandConfigurationNumber.SubnetMask)
                            .BuildGetSubnetMaskCommand());

                    Assert.AreEqual("The operation is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectOperationProvided>(()
                        => EthernetCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithAction(EthernetCommandConfigurationNumber.SubnetMask)
                            .BuildGetSubnetMaskCommand());

                    Assert.AreEqual("The operation provided is incorrect. Expected ? and not #",
                        exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectActionNumber
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectActionNumberProvided>(()
                        => EthernetCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithAction(EthernetCommandConfigurationNumber.MulticastAddress)
                            .BuildGetSubnetMaskCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 2 and not 5",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildGetDhcpCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = EthernetCommandBuilder.Create()
                    .WithOperation(CommandOperation.Get)
                    .WithAction(EthernetCommandConfigurationNumber.Dhcp)
                    .BuildGetDhcpCommand();

                Assert.AreEqual("?ETHERNET,4<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => EthernetCommandBuilder.Create()
                            .WithAction(EthernetCommandConfigurationNumber.Dhcp)
                            .BuildGetDhcpCommand());

                    Assert.AreEqual("The operation is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectOperationProvided>(()
                        => EthernetCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithAction(EthernetCommandConfigurationNumber.Dhcp)
                            .BuildGetDhcpCommand());

                    Assert.AreEqual("The operation provided is incorrect. Expected ? and not #",
                        exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectActionNumber
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectActionNumberProvided>(()
                        => EthernetCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithAction(EthernetCommandConfigurationNumber.MulticastAddress)
                            .BuildGetDhcpCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 4 and not 5",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildSetMulticastAddressCommand
        {
            [TestFixture]
            public class GivenMulticastAddress
            {
                [Test]
                public void ShouldReturnCommandString()
                {
                    var command = EthernetCommandBuilder.Create()
                        .WithOperation(CommandOperation.Set)
                        .WithAction(EthernetCommandConfigurationNumber.MulticastAddress)
                        .WithMulticastAddress(new IpAddress("192.168.1.1"))
                        .BuildSetMulticastAddressCommand();

                    Assert.AreEqual("#ETHERNET,5,192.168.1.1<CR><LF>", command);
                }
            }

            [TestFixture]
            public class GivenNoMulticastAddress
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<ParameterNotProvided>(() =>
                        EthernetCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithAction(EthernetCommandConfigurationNumber.MulticastAddress)
                            .BuildSetMulticastAddressCommand());

                    Assert.AreEqual("The parameter, multicast address, is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => EthernetCommandBuilder.Create()
                            .WithAction(EthernetCommandConfigurationNumber.MulticastAddress)
                            .BuildSetMulticastAddressCommand());

                    Assert.AreEqual("The operation is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectOperationProvided>(()
                        => EthernetCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithAction(EthernetCommandConfigurationNumber.MulticastAddress)
                            .BuildSetMulticastAddressCommand());

                    Assert.AreEqual("The operation provided is incorrect. Expected # and not ?",
                        exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectActionNumber
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectActionNumberProvided>(()
                        => EthernetCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithAction(EthernetCommandConfigurationNumber.IpAddress)
                            .BuildSetMulticastAddressCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 5 and not 0",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildGetMulticastAddressCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = EthernetCommandBuilder.Create()
                    .WithOperation(CommandOperation.Get)
                    .WithAction(EthernetCommandConfigurationNumber.MulticastAddress)
                    .BuildGetMulticastAddressCommand();

                Assert.AreEqual("?ETHERNET,5<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => EthernetCommandBuilder.Create()
                            .WithAction(EthernetCommandConfigurationNumber.MulticastAddress)
                            .BuildGetMulticastAddressCommand());

                    Assert.AreEqual("The operation is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectOperationProvided>(()
                        => EthernetCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithAction(EthernetCommandConfigurationNumber.MulticastAddress)
                            .BuildGetMulticastAddressCommand());

                    Assert.AreEqual("The operation provided is incorrect. Expected ? and not #",
                        exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectActionNumber
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectActionNumberProvided>(()
                        => EthernetCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithAction(EthernetCommandConfigurationNumber.IpAddress)
                            .BuildGetMulticastAddressCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 5 and not 0",
                        exception.Message);
                }
            }
        }
    }
}