using System;
using DbContext;
using DbRepos;
using Microsoft.Extensions.Logging;

using Seido.Utilities.SeedGenerator;
using Models;
using Models.DTO;

namespace Services
{
    public class csFriendsServiceOther2 : IFriendsService
    {
        const string _seedSource = "./other2-seeds.json";
        List<IPet> _pets = null;

        #region only for layer verification
        private Guid _guid = Guid.NewGuid();
        private string _instanceHeartbeat;

        public string InstanceHeartbeat => _instanceHeartbeat;
         #endregion

        #region constructors
        public csFriendsServiceOther2()
        {
            //only for layer verification
            _instanceHeartbeat = $"Heartbeat from class {this.GetType()} with instance Guid {_guid}. ";
        
            //Generate random list in the constructor
            var fn = Path.GetFullPath(_seedSource);
            var _seeder = new csSeedGenerator(fn);

            _pets = _seeder.ItemsToList<csPet>(5).ToList<IPet>();
        }
        #endregion

        #region Used for DI exploration only
        public Task<List<IPet>> DIExploration ()
        {
            /*
            var fn = Path.GetFullPath(_seedSource);
            var _seeder = new csSeedGenerator(fn);

            List<IPet> _pets = _seeder.ItemsToList<csPet>(5).ToList<IPet>();
            */
            return Task.FromResult(_pets);
        }
        #endregion

        #region Simple 1:1 calls in this case, but as Services expands, this will no longer be the case
        public Task<gstusrInfoAllDto> InfoAsync => throw new NotImplementedException();

        public Task<adminInfoDbDto> SeedAsync(loginUserSessionDto usr, int nrOfItems) => throw new NotImplementedException();
        public Task<adminInfoDbDto> RemoveSeedAsync(loginUserSessionDto usr, bool seeded) => throw new NotImplementedException();

        public Task<csRespPageDTO<IFriend>> ReadFriendsAsync(loginUserSessionDto usr, bool seeded, bool flat, string filter, int pageNumber, int pageSize) => throw new NotImplementedException();
        public Task<IFriend> ReadFriendAsync(loginUserSessionDto usr, Guid id, bool flat) => throw new NotImplementedException();
        public Task<IFriend> DeleteFriendAsync(loginUserSessionDto usr, Guid id) => throw new NotImplementedException();
        public Task<IFriend> UpdateFriendAsync(loginUserSessionDto usr, csFriendCUdto item) => throw new NotImplementedException();
        public Task<IFriend> CreateFriendAsync(loginUserSessionDto usr, csFriendCUdto item) => throw new NotImplementedException();

        public Task<csRespPageDTO<IAddress>> ReadAddressesAsync(loginUserSessionDto usr, bool seeded, bool flat, string filter, int pageNumber, int pageSize) => throw new NotImplementedException();
        public Task<IAddress> ReadAddressAsync(loginUserSessionDto usr, Guid id, bool flat) => throw new NotImplementedException();
        public Task<IAddress> DeleteAddressAsync(loginUserSessionDto usr, Guid id) => throw new NotImplementedException();
        public Task<IAddress> UpdateAddressAsync(loginUserSessionDto usr, csAddressCUdto item) => throw new NotImplementedException();
        public Task<IAddress> CreateAddressAsync(loginUserSessionDto usr, csAddressCUdto item) => throw new NotImplementedException();

        public Task<csRespPageDTO<IQuote>> ReadQuotesAsync(loginUserSessionDto usr, bool seeded, bool flat, string filter, int pageNumber, int pageSize) => throw new NotImplementedException();
        public Task<IQuote> ReadQuoteAsync(loginUserSessionDto usr, Guid id, bool flat) => throw new NotImplementedException();
        public Task<IQuote> DeleteQuoteAsync(loginUserSessionDto usr, Guid id) => throw new NotImplementedException();
        public Task<IQuote> UpdateQuoteAsync(loginUserSessionDto usr, csQuoteCUdto item) => throw new NotImplementedException();
        public Task<IQuote> CreateQuoteAsync(loginUserSessionDto usr, csQuoteCUdto item) => throw new NotImplementedException();

        public Task<csRespPageDTO<IPet>> ReadPetsAsync(loginUserSessionDto usr, bool seeded, bool flat, string filter, int pageNumber, int pageSize) => throw new NotImplementedException();
        public Task<IPet> ReadPetAsync(loginUserSessionDto usr, Guid id, bool flat) => throw new NotImplementedException();
        public Task<IPet> DeletePetAsync(loginUserSessionDto usr, Guid id) => throw new NotImplementedException();
        public Task<IPet> UpdatePetAsync(loginUserSessionDto usr, csPetCUdto item) => throw new NotImplementedException();
        public Task<IPet> CreatePetAsync(loginUserSessionDto usr, csPetCUdto item) => throw new NotImplementedException();
        #endregion
    }
}
