using System.Diagnostics;
using TrinityCore._3._3._5.ClientLibrary.Dbc;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore.Dbc.Net.Lib.Tests
{
    [TestClass]
    public class OpenFileTests
     {       
         [ClassInitialize]
         public static void TestInitialize(TestContext context)
         {
            DbcDirectory.Initialize(@Constants.DBC_FILE_PATH, DbcLocale.frFR);
         }
         
         [TestMethod]
         public void TestAchievement()
         {
            List<Achievement> records = DbcDirectory.Open<Achievement>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestAchievementCategory()
         {
            List<AchievementCategory> records = DbcDirectory.Open<AchievementCategory>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestAchievementCriteria()
         {
            List<AchievementCriteria> records = DbcDirectory.Open<AchievementCriteria>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestAnimationData()
         {
            List<AnimationData> records = DbcDirectory.Open<AnimationData>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestAreaGroup()
         {
            List<AreaGroup> records = DbcDirectory.Open<AreaGroup>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestAreaPOI()
         {
            List<AreaPOI> records = DbcDirectory.Open<AreaPOI>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestAreaTable()
         {
            List<AreaTable> records = DbcDirectory.Open<AreaTable>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestAreaTrigger()
         {
            List<AreaTrigger> records = DbcDirectory.Open<AreaTrigger>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestAttackAnimKits()
         {
            List<AttackAnimKits> records = DbcDirectory.Open<AttackAnimKits>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestAttackAnimTypes()
         {
            List<AttackAnimTypes> records = DbcDirectory.Open<AttackAnimTypes>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestAuctionHouse()
         {
            List<AuctionHouse> records = DbcDirectory.Open<AuctionHouse>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestBankBagSlotPrices()
         {
            List<BankBagSlotPrices> records = DbcDirectory.Open<BankBagSlotPrices>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestBannedAddOns()
         {
            List<BannedAddOns> records = DbcDirectory.Open<BannedAddOns>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestBarberShopStyle()
         {
            List<BarberShopStyle> records = DbcDirectory.Open<BarberShopStyle>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestBattlemasterList()
         {
            List<BattlemasterList> records = DbcDirectory.Open<BattlemasterList>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestCameraShakes()
         {
            List<CameraShakes> records = DbcDirectory.Open<CameraShakes>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestCfgCategories()
         {
            List<CfgCategories> records = DbcDirectory.Open<CfgCategories>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestCfgConfigs()
         {
            List<CfgConfigs> records = DbcDirectory.Open<CfgConfigs>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestCharacterFacialHairStyles()
         {
            List<CharacterFacialHairStyles> records = DbcDirectory.Open<CharacterFacialHairStyles>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestCharBaseInfo()
         {
            List<CharBaseInfo> records = DbcDirectory.Open<CharBaseInfo>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestCharHairGeosets()
         {
            List<CharHairGeosets> records = DbcDirectory.Open<CharHairGeosets>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestCharHairTextures()
         {
            List<CharHairTextures> records = DbcDirectory.Open<CharHairTextures>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestCharSections()
         {
            List<CharSections> records = DbcDirectory.Open<CharSections>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestCharStartOutfit()
         {
            List<CharStartOutfit> records = DbcDirectory.Open<CharStartOutfit>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestCharTitles()
         {
            List<CharTitles> records = DbcDirectory.Open<CharTitles>();
            Assert.IsNotNull(records);
         }
         
         /**************************************************************
         *** TEST CURRENTLY DISABLED DUE TO A BAD DBC FILE           ***
         ***************************************************************
         
         [TestMethod]
         public void TestCharVariations()
         {
            List<CharVariations> records = DbcDirectory.Open<CharVariations>();
            Assert.IsNotNull(records);
         }
         
         **************************************************************/
         
         [TestMethod]
         public void TestChatChannels()
         {
            List<ChatChannels> records = DbcDirectory.Open<ChatChannels>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestChatProfanity()
         {
            List<ChatProfanity> records = DbcDirectory.Open<ChatProfanity>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestChrClasses()
         {
            List<ChrClasses> records = DbcDirectory.Open<ChrClasses>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestChrRaces()
         {
            List<ChrRaces> records = DbcDirectory.Open<ChrRaces>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestCinematicCamera()
         {
            List<CinematicCamera> records = DbcDirectory.Open<CinematicCamera>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestCinematicSequences()
         {
            List<CinematicSequences> records = DbcDirectory.Open<CinematicSequences>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestCreatureDisplayInfo()
         {
            List<CreatureDisplayInfo> records = DbcDirectory.Open<CreatureDisplayInfo>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestCreatureDisplayInfoExtra()
         {
            List<CreatureDisplayInfoExtra> records = DbcDirectory.Open<CreatureDisplayInfoExtra>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestCreatureFamily()
         {
            List<CreatureFamily> records = DbcDirectory.Open<CreatureFamily>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestCreatureModelData()
         {
            List<CreatureModelData> records = DbcDirectory.Open<CreatureModelData>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestCreatureMovementInfo()
         {
            List<CreatureMovementInfo> records = DbcDirectory.Open<CreatureMovementInfo>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestCreatureSoundData()
         {
            List<CreatureSoundData> records = DbcDirectory.Open<CreatureSoundData>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestCreatureSpellData()
         {
            List<CreatureSpellData> records = DbcDirectory.Open<CreatureSpellData>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestCreatureType()
         {
            List<CreatureType> records = DbcDirectory.Open<CreatureType>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestCurrencyCategory()
         {
            List<CurrencyCategory> records = DbcDirectory.Open<CurrencyCategory>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestCurrencyTypes()
         {
            List<CurrencyTypes> records = DbcDirectory.Open<CurrencyTypes>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestDanceMoves()
         {
            List<DanceMoves> records = DbcDirectory.Open<DanceMoves>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestDeathThudLookups()
         {
            List<DeathThudLookups> records = DbcDirectory.Open<DeathThudLookups>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestDeclinedWord()
         {
            List<DeclinedWord> records = DbcDirectory.Open<DeclinedWord>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestDeclinedWordCases()
         {
            List<DeclinedWordCases> records = DbcDirectory.Open<DeclinedWordCases>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestDestructibleModelData()
         {
            List<DestructibleModelData> records = DbcDirectory.Open<DestructibleModelData>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestDungeonEncounter()
         {
            List<DungeonEncounter> records = DbcDirectory.Open<DungeonEncounter>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestDungeonMap()
         {
            List<DungeonMap> records = DbcDirectory.Open<DungeonMap>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestDungeonMapChunk()
         {
            List<DungeonMapChunk> records = DbcDirectory.Open<DungeonMapChunk>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestDurabilityCosts()
         {
            List<DurabilityCosts> records = DbcDirectory.Open<DurabilityCosts>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestDurabilityQuality()
         {
            List<DurabilityQuality> records = DbcDirectory.Open<DurabilityQuality>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestEmotes()
         {
            List<Emotes> records = DbcDirectory.Open<Emotes>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestEmotesText()
         {
            List<EmotesText> records = DbcDirectory.Open<EmotesText>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestEmotesTextData()
         {
            List<EmotesTextData> records = DbcDirectory.Open<EmotesTextData>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestEmotesTextSound()
         {
            List<EmotesTextSound> records = DbcDirectory.Open<EmotesTextSound>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestEnvironmentalDamage()
         {
            List<EnvironmentalDamage> records = DbcDirectory.Open<EnvironmentalDamage>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestExhaustion()
         {
            List<Exhaustion> records = DbcDirectory.Open<Exhaustion>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestFaction()
         {
            List<Faction> records = DbcDirectory.Open<Faction>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestFactionGroup()
         {
            List<FactionGroup> records = DbcDirectory.Open<FactionGroup>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestFactionTemplate()
         {
            List<FactionTemplate> records = DbcDirectory.Open<FactionTemplate>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestFileData()
         {
            List<FileData> records = DbcDirectory.Open<FileData>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestFootprintTextures()
         {
            List<FootprintTextures> records = DbcDirectory.Open<FootprintTextures>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestFootstepTerrainLookup()
         {
            List<FootstepTerrainLookup> records = DbcDirectory.Open<FootstepTerrainLookup>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestGameObjectArtKit()
         {
            List<GameObjectArtKit> records = DbcDirectory.Open<GameObjectArtKit>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestGameObjectDisplayInfo()
         {
            List<GameObjectDisplayInfo> records = DbcDirectory.Open<GameObjectDisplayInfo>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestGameTables()
         {
            List<GameTables> records = DbcDirectory.Open<GameTables>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestGameTips()
         {
            List<GameTips> records = DbcDirectory.Open<GameTips>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestGemProperties()
         {
            List<GemProperties> records = DbcDirectory.Open<GemProperties>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestGlyphProperties()
         {
            List<GlyphProperties> records = DbcDirectory.Open<GlyphProperties>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestGlyphSlot()
         {
            List<GlyphSlot> records = DbcDirectory.Open<GlyphSlot>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestGMSurveyAnswers()
         {
            List<GMSurveyAnswers> records = DbcDirectory.Open<GMSurveyAnswers>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestGMSurveyCurrentSurvey()
         {
            List<GMSurveyCurrentSurvey> records = DbcDirectory.Open<GMSurveyCurrentSurvey>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestGMSurveyQuestions()
         {
            List<GMSurveyQuestions> records = DbcDirectory.Open<GMSurveyQuestions>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestGMSurveySurveys()
         {
            List<GMSurveySurveys> records = DbcDirectory.Open<GMSurveySurveys>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestGMTicketCategory()
         {
            List<GMTicketCategory> records = DbcDirectory.Open<GMTicketCategory>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestGroundEffectDoodad()
         {
            List<GroundEffectDoodad> records = DbcDirectory.Open<GroundEffectDoodad>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestGroundEffectTexture()
         {
            List<GroundEffectTexture> records = DbcDirectory.Open<GroundEffectTexture>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestGtBarberShopCostBase()
         {
            List<GtBarberShopCostBase> records = DbcDirectory.Open<GtBarberShopCostBase>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestGtChanceToMeleeCrit()
         {
            List<GtChanceToMeleeCrit> records = DbcDirectory.Open<GtChanceToMeleeCrit>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestGtChanceToMeleeCritBase()
         {
            List<GtChanceToMeleeCritBase> records = DbcDirectory.Open<GtChanceToMeleeCritBase>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestGtChanceToSpellCrit()
         {
            List<GtChanceToSpellCrit> records = DbcDirectory.Open<GtChanceToSpellCrit>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestGtChanceToSpellCritBase()
         {
            List<GtChanceToSpellCritBase> records = DbcDirectory.Open<GtChanceToSpellCritBase>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestGtCombatRatings()
         {
            List<GtCombatRatings> records = DbcDirectory.Open<GtCombatRatings>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestGtNPCManaCostScaler()
         {
            List<GtNPCManaCostScaler> records = DbcDirectory.Open<GtNPCManaCostScaler>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestGtOCTClassCombatRatingScalar()
         {
            List<GtOCTClassCombatRatingScalar> records = DbcDirectory.Open<GtOCTClassCombatRatingScalar>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestGtOCTRegenHP()
         {
            List<GtOCTRegenHP> records = DbcDirectory.Open<GtOCTRegenHP>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestGtOCTRegenMP()
         {
            List<GtOCTRegenMP> records = DbcDirectory.Open<GtOCTRegenMP>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestGtRegenHPPerSpt()
         {
            List<GtRegenHPPerSpt> records = DbcDirectory.Open<GtRegenHPPerSpt>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestGtRegenMPPerSpt()
         {
            List<GtRegenMPPerSpt> records = DbcDirectory.Open<GtRegenMPPerSpt>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestHelmetGeosetVisData()
         {
            List<HelmetGeosetVisData> records = DbcDirectory.Open<HelmetGeosetVisData>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestHolidayDescriptions()
         {
            List<HolidayDescriptions> records = DbcDirectory.Open<HolidayDescriptions>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestHolidayNames()
         {
            List<HolidayNames> records = DbcDirectory.Open<HolidayNames>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestHolidays()
         {
            List<Holidays> records = DbcDirectory.Open<Holidays>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestItem()
         {
            List<Item> records = DbcDirectory.Open<Item>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestItemBagFamily()
         {
            List<ItemBagFamily> records = DbcDirectory.Open<ItemBagFamily>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestItemClass()
         {
            List<ItemClass> records = DbcDirectory.Open<ItemClass>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestItemCondExtCosts()
         {
            List<ItemCondExtCosts> records = DbcDirectory.Open<ItemCondExtCosts>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestItemDisplayInfo()
         {
            List<ItemDisplayInfo> records = DbcDirectory.Open<ItemDisplayInfo>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestItemExtendedCost()
         {
            List<ItemExtendedCost> records = DbcDirectory.Open<ItemExtendedCost>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestItemGroupSounds()
         {
            List<ItemGroupSounds> records = DbcDirectory.Open<ItemGroupSounds>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestItemLimitCategory()
         {
            List<ItemLimitCategory> records = DbcDirectory.Open<ItemLimitCategory>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestItemPetFood()
         {
            List<ItemPetFood> records = DbcDirectory.Open<ItemPetFood>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestItemPurchaseGroup()
         {
            List<ItemPurchaseGroup> records = DbcDirectory.Open<ItemPurchaseGroup>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestItemRandomProperties()
         {
            List<ItemRandomProperties> records = DbcDirectory.Open<ItemRandomProperties>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestItemRandomSuffix()
         {
            List<ItemRandomSuffix> records = DbcDirectory.Open<ItemRandomSuffix>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestItemSet()
         {
            List<ItemSet> records = DbcDirectory.Open<ItemSet>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestItemSubClass()
         {
            List<ItemSubClass> records = DbcDirectory.Open<ItemSubClass>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestItemSubClassMask()
         {
            List<ItemSubClassMask> records = DbcDirectory.Open<ItemSubClassMask>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestItemVisualEffects()
         {
            List<ItemVisualEffects> records = DbcDirectory.Open<ItemVisualEffects>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestItemVisuals()
         {
            List<ItemVisuals> records = DbcDirectory.Open<ItemVisuals>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestLanguages()
         {
            List<Languages> records = DbcDirectory.Open<Languages>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestLanguageWords()
         {
            List<LanguageWords> records = DbcDirectory.Open<LanguageWords>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestLFGDungeonExpansion()
         {
            List<LFGDungeonExpansion> records = DbcDirectory.Open<LFGDungeonExpansion>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestLFGDungeonGroup()
         {
            List<LFGDungeonGroup> records = DbcDirectory.Open<LFGDungeonGroup>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestLFGDungeons()
         {
            List<LFGDungeons> records = DbcDirectory.Open<LFGDungeons>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestLight()
         {
            List<Light> records = DbcDirectory.Open<Light>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestLightFloatBand()
         {
            List<LightFloatBand> records = DbcDirectory.Open<LightFloatBand>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestLightIntBand()
         {
            List<LightIntBand> records = DbcDirectory.Open<LightIntBand>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestLightParams()
         {
            List<LightParams> records = DbcDirectory.Open<LightParams>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestLightSkybox()
         {
            List<LightSkybox> records = DbcDirectory.Open<LightSkybox>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestLiquidMaterial()
         {
            List<LiquidMaterial> records = DbcDirectory.Open<LiquidMaterial>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestLiquidType()
         {
            List<LiquidType> records = DbcDirectory.Open<LiquidType>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestLoadingScreens()
         {
            List<LoadingScreens> records = DbcDirectory.Open<LoadingScreens>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestLoadingScreenTaxiSplines()
         {
            List<LoadingScreenTaxiSplines> records = DbcDirectory.Open<LoadingScreenTaxiSplines>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestLock()
         {
            List<Lock> records = DbcDirectory.Open<Lock>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestLockType()
         {
            List<LockType> records = DbcDirectory.Open<LockType>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestMailTemplate()
         {
            List<MailTemplate> records = DbcDirectory.Open<MailTemplate>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestMap()
         {
            List<Map> records = DbcDirectory.Open<Map>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestMapDifficulty()
         {
            List<MapDifficulty> records = DbcDirectory.Open<MapDifficulty>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestMaterial()
         {
            List<Material> records = DbcDirectory.Open<Material>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestMovie()
         {
            List<Movie> records = DbcDirectory.Open<Movie>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestMovieFileData()
         {
            List<MovieFileData> records = DbcDirectory.Open<MovieFileData>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestMovieVariation()
         {
            List<MovieVariation> records = DbcDirectory.Open<MovieVariation>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestNameGen()
         {
            List<NameGen> records = DbcDirectory.Open<NameGen>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestNamesProfanity()
         {
            List<NamesProfanity> records = DbcDirectory.Open<NamesProfanity>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestNamesReserved()
         {
            List<NamesReserved> records = DbcDirectory.Open<NamesReserved>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestNPCSounds()
         {
            List<NPCSounds> records = DbcDirectory.Open<NPCSounds>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestObjectEffect()
         {
            List<ObjectEffect> records = DbcDirectory.Open<ObjectEffect>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestObjectEffectGroup()
         {
            List<ObjectEffectGroup> records = DbcDirectory.Open<ObjectEffectGroup>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestObjectEffectModifier()
         {
            List<ObjectEffectModifier> records = DbcDirectory.Open<ObjectEffectModifier>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestObjectEffectPackage()
         {
            List<ObjectEffectPackage> records = DbcDirectory.Open<ObjectEffectPackage>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestObjectEffectPackageElem()
         {
            List<ObjectEffectPackageElem> records = DbcDirectory.Open<ObjectEffectPackageElem>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestOverrideSpellData()
         {
            List<OverrideSpellData> records = DbcDirectory.Open<OverrideSpellData>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestPackage()
         {
            List<Package> records = DbcDirectory.Open<Package>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestPageTextMaterial()
         {
            List<PageTextMaterial> records = DbcDirectory.Open<PageTextMaterial>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestPaperDollItemFrame()
         {
            List<PaperDollItemFrame> records = DbcDirectory.Open<PaperDollItemFrame>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestParticleColor()
         {
            List<ParticleColor> records = DbcDirectory.Open<ParticleColor>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestPetitionType()
         {
            List<PetitionType> records = DbcDirectory.Open<PetitionType>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestPetPersonality()
         {
            List<PetPersonality> records = DbcDirectory.Open<PetPersonality>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestPowerDisplay()
         {
            List<PowerDisplay> records = DbcDirectory.Open<PowerDisplay>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestPvpDifficulty()
         {
            List<PvpDifficulty> records = DbcDirectory.Open<PvpDifficulty>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestQuestFactionReward()
         {
            List<QuestFactionReward> records = DbcDirectory.Open<QuestFactionReward>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestQuestInfo()
         {
            List<QuestInfo> records = DbcDirectory.Open<QuestInfo>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestQuestSort()
         {
            List<QuestSort> records = DbcDirectory.Open<QuestSort>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestQuestXP()
         {
            List<QuestXP> records = DbcDirectory.Open<QuestXP>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestRandPropPoints()
         {
            List<RandPropPoints> records = DbcDirectory.Open<RandPropPoints>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestResistances()
         {
            List<Resistances> records = DbcDirectory.Open<Resistances>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestScalingStatDistribution()
         {
            List<ScalingStatDistribution> records = DbcDirectory.Open<ScalingStatDistribution>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestScalingStatValues()
         {
            List<ScalingStatValues> records = DbcDirectory.Open<ScalingStatValues>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestScreenEffect()
         {
            List<ScreenEffect> records = DbcDirectory.Open<ScreenEffect>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestServerMessages()
         {
            List<ServerMessages> records = DbcDirectory.Open<ServerMessages>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestSheatheSoundLookups()
         {
            List<SheatheSoundLookups> records = DbcDirectory.Open<SheatheSoundLookups>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestSkillCostsData()
         {
            List<SkillCostsData> records = DbcDirectory.Open<SkillCostsData>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestSkillLine()
         {
            List<SkillLine> records = DbcDirectory.Open<SkillLine>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestSkillLineAbility()
         {
            List<SkillLineAbility> records = DbcDirectory.Open<SkillLineAbility>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestSkillLineCategory()
         {
            List<SkillLineCategory> records = DbcDirectory.Open<SkillLineCategory>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestSkillRaceClassInfo()
         {
            List<SkillRaceClassInfo> records = DbcDirectory.Open<SkillRaceClassInfo>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestSkillTiers()
         {
            List<SkillTiers> records = DbcDirectory.Open<SkillTiers>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestSoundAmbience()
         {
            List<SoundAmbience> records = DbcDirectory.Open<SoundAmbience>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestSoundEmitters()
         {
            List<SoundEmitters> records = DbcDirectory.Open<SoundEmitters>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestSoundEntries()
         {
            List<SoundEntries> records = DbcDirectory.Open<SoundEntries>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestSoundEntriesAdvanced()
         {
            List<SoundEntriesAdvanced> records = DbcDirectory.Open<SoundEntriesAdvanced>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestSoundFilter()
         {
            List<SoundFilter> records = DbcDirectory.Open<SoundFilter>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestSoundFilterElem()
         {
            List<SoundFilterElem> records = DbcDirectory.Open<SoundFilterElem>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestSoundProviderPreferences()
         {
            List<SoundProviderPreferences> records = DbcDirectory.Open<SoundProviderPreferences>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestSoundSamplePreferences()
         {
            List<SoundSamplePreferences> records = DbcDirectory.Open<SoundSamplePreferences>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestSoundWaterType()
         {
            List<SoundWaterType> records = DbcDirectory.Open<SoundWaterType>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestSpamMessages()
         {
            List<SpamMessages> records = DbcDirectory.Open<SpamMessages>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestSpell()
         {
            List<Spell> records = DbcDirectory.Open<Spell>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestSpellCastTimes()
         {
            List<SpellCastTimes> records = DbcDirectory.Open<SpellCastTimes>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestSpellCategory()
         {
            List<SpellCategory> records = DbcDirectory.Open<SpellCategory>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestSpellChainEffects()
         {
            List<SpellChainEffects> records = DbcDirectory.Open<SpellChainEffects>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestSpellDescriptionVariables()
         {
            List<SpellDescriptionVariables> records = DbcDirectory.Open<SpellDescriptionVariables>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestSpellDifficulty()
         {
            List<SpellDifficulty> records = DbcDirectory.Open<SpellDifficulty>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestSpellDispelType()
         {
            List<SpellDispelType> records = DbcDirectory.Open<SpellDispelType>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestSpellDuration()
         {
            List<SpellDuration> records = DbcDirectory.Open<SpellDuration>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestSpellEffectCameraShakes()
         {
            List<SpellEffectCameraShakes> records = DbcDirectory.Open<SpellEffectCameraShakes>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestSpellFocusObject()
         {
            List<SpellFocusObject> records = DbcDirectory.Open<SpellFocusObject>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestSpellIcon()
         {
            List<SpellIcon> records = DbcDirectory.Open<SpellIcon>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestSpellItemEnchantment()
         {
            List<SpellItemEnchantment> records = DbcDirectory.Open<SpellItemEnchantment>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestSpellItemEnchantmentCondition()
         {
            List<SpellItemEnchantmentCondition> records = DbcDirectory.Open<SpellItemEnchantmentCondition>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestSpellMechanic()
         {
            List<SpellMechanic> records = DbcDirectory.Open<SpellMechanic>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestSpellMissile()
         {
            List<SpellMissile> records = DbcDirectory.Open<SpellMissile>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestSpellMissileMotion()
         {
            List<SpellMissileMotion> records = DbcDirectory.Open<SpellMissileMotion>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestSpellRadius()
         {
            List<SpellRadius> records = DbcDirectory.Open<SpellRadius>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestSpellRange()
         {
            List<SpellRange> records = DbcDirectory.Open<SpellRange>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestSpellRuneCost()
         {
            List<SpellRuneCost> records = DbcDirectory.Open<SpellRuneCost>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestSpellShapeshiftForm()
         {
            List<SpellShapeshiftForm> records = DbcDirectory.Open<SpellShapeshiftForm>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestSpellVisual()
         {
            List<SpellVisual> records = DbcDirectory.Open<SpellVisual>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestSpellVisualEffectName()
         {
            List<SpellVisualEffectName> records = DbcDirectory.Open<SpellVisualEffectName>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestSpellVisualKit()
         {
            List<SpellVisualKit> records = DbcDirectory.Open<SpellVisualKit>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestSpellVisualKitAreaModel()
         {
            List<SpellVisualKitAreaModel> records = DbcDirectory.Open<SpellVisualKitAreaModel>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestSpellVisualKitModelAttach()
         {
            List<SpellVisualKitModelAttach> records = DbcDirectory.Open<SpellVisualKitModelAttach>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestSpellVisualPrecastTransitions()
         {
            List<SpellVisualPrecastTransitions> records = DbcDirectory.Open<SpellVisualPrecastTransitions>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestStableSlotPrices()
         {
            List<StableSlotPrices> records = DbcDirectory.Open<StableSlotPrices>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestStartupStrings()
         {
            List<StartupStrings> records = DbcDirectory.Open<StartupStrings>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestStationery()
         {
            List<Stationery> records = DbcDirectory.Open<Stationery>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestStringLookups()
         {
            List<StringLookups> records = DbcDirectory.Open<StringLookups>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestSummonProperties()
         {
            List<SummonProperties> records = DbcDirectory.Open<SummonProperties>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestTalent()
         {
            List<Talent> records = DbcDirectory.Open<Talent>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestTalentTab()
         {
            List<TalentTab> records = DbcDirectory.Open<TalentTab>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestTaxiNodes()
         {
            List<TaxiNodes> records = DbcDirectory.Open<TaxiNodes>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestTaxiPath()
         {
            List<TaxiPath> records = DbcDirectory.Open<TaxiPath>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestTaxiPathNode()
         {
            List<TaxiPathNode> records = DbcDirectory.Open<TaxiPathNode>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestTeamContributionPoints()
         {
            List<TeamContributionPoints> records = DbcDirectory.Open<TeamContributionPoints>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestTerrainType()
         {
            List<TerrainType> records = DbcDirectory.Open<TerrainType>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestTerrainTypeSounds()
         {
            List<TerrainTypeSounds> records = DbcDirectory.Open<TerrainTypeSounds>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestTotemCategory()
         {
            List<TotemCategory> records = DbcDirectory.Open<TotemCategory>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestTransportAnimation()
         {
            List<TransportAnimation> records = DbcDirectory.Open<TransportAnimation>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestTransportPhysics()
         {
            List<TransportPhysics> records = DbcDirectory.Open<TransportPhysics>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestTransportRotation()
         {
            List<TransportRotation> records = DbcDirectory.Open<TransportRotation>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestUISoundLookups()
         {
            List<UISoundLookups> records = DbcDirectory.Open<UISoundLookups>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestUnitBlood()
         {
            List<UnitBlood> records = DbcDirectory.Open<UnitBlood>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestUnitBloodLevels()
         {
            List<UnitBloodLevels> records = DbcDirectory.Open<UnitBloodLevels>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestVehicle()
         {
            List<Vehicle> records = DbcDirectory.Open<Vehicle>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestVehicleSeat()
         {
            List<VehicleSeat> records = DbcDirectory.Open<VehicleSeat>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestVehicleUIIndicator()
         {
            List<VehicleUIIndicator> records = DbcDirectory.Open<VehicleUIIndicator>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestVehicleUIIndSeat()
         {
            List<VehicleUIIndSeat> records = DbcDirectory.Open<VehicleUIIndSeat>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestVideoHardware()
         {
            List<VideoHardware> records = DbcDirectory.Open<VideoHardware>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestVocalUISounds()
         {
            List<VocalUISounds> records = DbcDirectory.Open<VocalUISounds>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestWeaponImpactSounds()
         {
            List<WeaponImpactSounds> records = DbcDirectory.Open<WeaponImpactSounds>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestWeaponSwingSounds2()
         {
            List<WeaponSwingSounds2> records = DbcDirectory.Open<WeaponSwingSounds2>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestWeather()
         {
            List<Weather> records = DbcDirectory.Open<Weather>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestWMOAreaTable()
         {
            List<WMOAreaTable> records = DbcDirectory.Open<WMOAreaTable>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestWorldChunkSounds()
         {
            List<WorldChunkSounds> records = DbcDirectory.Open<WorldChunkSounds>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestWorldMapArea()
         {
            List<WorldMapArea> records = DbcDirectory.Open<WorldMapArea>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestWorldMapContinent()
         {
            List<WorldMapContinent> records = DbcDirectory.Open<WorldMapContinent>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestWorldMapOverlay()
         {
            List<WorldMapOverlay> records = DbcDirectory.Open<WorldMapOverlay>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestWorldMapTransforms()
         {
            List<WorldMapTransforms> records = DbcDirectory.Open<WorldMapTransforms>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestWorldSafeLocs()
         {
            List<WorldSafeLocs> records = DbcDirectory.Open<WorldSafeLocs>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestWorldStateUI()
         {
            List<WorldStateUI> records = DbcDirectory.Open<WorldStateUI>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestWorldStateZoneSounds()
         {
            List<WorldStateZoneSounds> records = DbcDirectory.Open<WorldStateZoneSounds>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestWowErrorStrings()
         {
            List<WowErrorStrings> records = DbcDirectory.Open<WowErrorStrings>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestZoneIntroMusicTable()
         {
            List<ZoneIntroMusicTable> records = DbcDirectory.Open<ZoneIntroMusicTable>();
            Assert.IsNotNull(records);
         }
         
         [TestMethod]
         public void TestZoneMusic()
         {
            List<ZoneMusic> records = DbcDirectory.Open<ZoneMusic>();
            Assert.IsNotNull(records);
         }
         
     }
}
