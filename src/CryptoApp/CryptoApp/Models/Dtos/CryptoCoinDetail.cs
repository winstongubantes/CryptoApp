using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CryptoApp.Models.Dtos
{
    public class Localization
    {

        [JsonProperty("en")]
        public string En { get; set; }

        [JsonProperty("de")]
        public string De { get; set; }

        [JsonProperty("es")]
        public string Es { get; set; }

        [JsonProperty("fr")]
        public string Fr { get; set; }

        [JsonProperty("it")]
        public string It { get; set; }

        [JsonProperty("pl")]
        public string Pl { get; set; }

        [JsonProperty("ro")]
        public string Ro { get; set; }

        [JsonProperty("hu")]
        public string Hu { get; set; }

        [JsonProperty("nl")]
        public string Nl { get; set; }

        [JsonProperty("pt")]
        public string Pt { get; set; }

        [JsonProperty("sv")]
        public string Sv { get; set; }

        [JsonProperty("vi")]
        public string Vi { get; set; }

        [JsonProperty("tr")]
        public string Tr { get; set; }

        [JsonProperty("ru")]
        public string Ru { get; set; }

        [JsonProperty("ja")]
        public string Ja { get; set; }

        [JsonProperty("zh")]
        public string Zh { get; set; }

        [JsonProperty("zh-tw")]
        public string ZhTw { get; set; }

        [JsonProperty("ko")]
        public string Ko { get; set; }

        [JsonProperty("ar")]
        public string Ar { get; set; }

        [JsonProperty("th")]
        public string Th { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public class Description
    {

        [JsonProperty("en")]
        public string En { get; set; }

        [JsonProperty("de")]
        public string De { get; set; }

        [JsonProperty("es")]
        public string Es { get; set; }

        [JsonProperty("fr")]
        public string Fr { get; set; }

        [JsonProperty("it")]
        public string It { get; set; }

        [JsonProperty("pl")]
        public string Pl { get; set; }

        [JsonProperty("ro")]
        public string Ro { get; set; }

        [JsonProperty("hu")]
        public string Hu { get; set; }

        [JsonProperty("nl")]
        public string Nl { get; set; }

        [JsonProperty("pt")]
        public string Pt { get; set; }

        [JsonProperty("sv")]
        public string Sv { get; set; }

        [JsonProperty("vi")]
        public string Vi { get; set; }

        [JsonProperty("tr")]
        public string Tr { get; set; }

        [JsonProperty("ru")]
        public string Ru { get; set; }

        [JsonProperty("ja")]
        public string Ja { get; set; }

        [JsonProperty("zh")]
        public string Zh { get; set; }

        [JsonProperty("zh-tw")]
        public string ZhTw { get; set; }

        [JsonProperty("ko")]
        public string Ko { get; set; }

        [JsonProperty("ar")]
        public string Ar { get; set; }

        [JsonProperty("th")]
        public string Th { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public class ReposUrl
    {

        [JsonProperty("github")]
        public IList<string> Github { get; set; }

        [JsonProperty("bitbucket")]
        public IList<object> Bitbucket { get; set; }
    }

    public class Links
    {

        [JsonProperty("homepage")]
        public IList<string> Homepage { get; set; }

        [JsonProperty("blockchain_site")]
        public IList<string> BlockchainSite { get; set; }

        [JsonProperty("official_forum_url")]
        public IList<string> OfficialForumUrl { get; set; }

        [JsonProperty("chat_url")]
        public IList<string> ChatUrl { get; set; }

        [JsonProperty("announcement_url")]
        public IList<string> AnnouncementUrl { get; set; }

        [JsonProperty("twitter_screen_name")]
        public string TwitterScreenName { get; set; }

        [JsonProperty("facebook_username")]
        public string FacebookUsername { get; set; }

        [JsonProperty("bitcointalk_thread_identifier")]
        public object BitcointalkThreadIdentifier { get; set; }

        [JsonProperty("telegram_channel_identifier")]
        public string TelegramChannelIdentifier { get; set; }

        [JsonProperty("subreddit_url")]
        public string SubredditUrl { get; set; }

        [JsonProperty("repos_url")]
        public ReposUrl ReposUrl { get; set; }
    }

    public class Image
    {

        [JsonProperty("thumb")]
        public string Thumb { get; set; }

        [JsonProperty("small")]
        public string Small { get; set; }

        [JsonProperty("large")]
        public string Large { get; set; }
    }

    public class CurrentPrice
    {

        [JsonProperty("aed")]
        public double Aed { get; set; }

        [JsonProperty("ars")]
        public double Ars { get; set; }

        [JsonProperty("aud")]
        public double Aud { get; set; }

        [JsonProperty("bch")]
        public double Bch { get; set; }

        [JsonProperty("bdt")]
        public double Bdt { get; set; }

        [JsonProperty("bhd")]
        public double Bhd { get; set; }

        [JsonProperty("bmd")]
        public double Bmd { get; set; }

        [JsonProperty("bnb")]
        public double Bnb { get; set; }

        [JsonProperty("brl")]
        public double Brl { get; set; }

        [JsonProperty("btc")]
        public double Btc { get; set; }

        [JsonProperty("cad")]
        public double Cad { get; set; }

        [JsonProperty("chf")]
        public double Chf { get; set; }

        [JsonProperty("clp")]
        public double Clp { get; set; }

        [JsonProperty("cny")]
        public double Cny { get; set; }

        [JsonProperty("czk")]
        public double Czk { get; set; }

        [JsonProperty("dkk")]
        public double Dkk { get; set; }

        [JsonProperty("dot")]
        public double Dot { get; set; }

        [JsonProperty("eos")]
        public double Eos { get; set; }

        [JsonProperty("eth")]
        public double Eth { get; set; }

        [JsonProperty("eur")]
        public double Eur { get; set; }

        [JsonProperty("gbp")]
        public double Gbp { get; set; }

        [JsonProperty("hkd")]
        public double Hkd { get; set; }

        [JsonProperty("huf")]
        public double Huf { get; set; }

        [JsonProperty("idr")]
        public double Idr { get; set; }

        [JsonProperty("ils")]
        public double Ils { get; set; }

        [JsonProperty("inr")]
        public double Inr { get; set; }

        [JsonProperty("jpy")]
        public double Jpy { get; set; }

        [JsonProperty("krw")]
        public double Krw { get; set; }

        [JsonProperty("kwd")]
        public double Kwd { get; set; }

        [JsonProperty("lkr")]
        public double Lkr { get; set; }

        [JsonProperty("ltc")]
        public double Ltc { get; set; }

        [JsonProperty("mmk")]
        public double Mmk { get; set; }

        [JsonProperty("mxn")]
        public double Mxn { get; set; }

        [JsonProperty("myr")]
        public double Myr { get; set; }

        [JsonProperty("ngn")]
        public double Ngn { get; set; }

        [JsonProperty("nok")]
        public double Nok { get; set; }

        [JsonProperty("nzd")]
        public double Nzd { get; set; }

        [JsonProperty("php")]
        public double Php { get; set; }

        [JsonProperty("pkr")]
        public double Pkr { get; set; }

        [JsonProperty("pln")]
        public double Pln { get; set; }

        [JsonProperty("rub")]
        public double Rub { get; set; }

        [JsonProperty("sar")]
        public double Sar { get; set; }

        [JsonProperty("sek")]
        public double Sek { get; set; }

        [JsonProperty("sgd")]
        public double Sgd { get; set; }

        [JsonProperty("thb")]
        public double Thb { get; set; }

        [JsonProperty("try")]
        public double Try { get; set; }

        [JsonProperty("twd")]
        public double Twd { get; set; }

        [JsonProperty("uah")]
        public double Uah { get; set; }

        [JsonProperty("usd")]
        public double Usd { get; set; }

        [JsonProperty("vef")]
        public double Vef { get; set; }

        [JsonProperty("vnd")]
        public double Vnd { get; set; }

        [JsonProperty("xag")]
        public double Xag { get; set; }

        [JsonProperty("xau")]
        public double Xau { get; set; }

        [JsonProperty("xdr")]
        public double Xdr { get; set; }

        [JsonProperty("xlm")]
        public double Xlm { get; set; }

        [JsonProperty("xrp")]
        public double Xrp { get; set; }

        [JsonProperty("yfi")]
        public double Yfi { get; set; }

        [JsonProperty("zar")]
        public double Zar { get; set; }
    }

    public class MarketData
    {

        [JsonProperty("current_price")]
        public CurrentPrice CurrentPrice { get; set; }
    }


    public class CryptoCoinDetail
    {

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("asset_platform_id")]
        public object AssetPlatformId { get; set; }

        [JsonProperty("block_time_in_minutes")]
        public int BlockTimeInMinutes { get; set; }

        [JsonProperty("hashing_algorithm")]
        public string HashingAlgorithm { get; set; }

        [JsonProperty("categories")]
        public IList<string> Categories { get; set; }

        [JsonProperty("public_notice")]
        public object PublicNotice { get; set; }

        [JsonProperty("localization")]
        public Localization Localization { get; set; }

        [JsonProperty("description")]
        public Description Description { get; set; }

        [JsonProperty("links")]
        public Links Links { get; set; }

        [JsonProperty("image")]
        public Image Image { get; set; }

        [JsonProperty("country_origin")]
        public string CountryOrigin { get; set; }

        [JsonProperty("genesis_date")]
        public string GenesisDate { get; set; }

        [JsonProperty("market_data")]
        public MarketData MarketData { get; set; }

        [JsonProperty("last_updated")]
        public DateTime LastUpdated { get; set; }
    }
}
