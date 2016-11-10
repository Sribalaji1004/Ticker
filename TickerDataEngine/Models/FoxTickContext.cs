using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using FOXTickerDataEngine.Models.Mapping;

namespace FOXTickerDataEngine.Models
{
    public class FoxTickContext : DbContext
    {
        static FoxTickContext()
        {
            Database.SetInitializer<FoxTickContext>(null);
        }

		public FoxTickContext()
			: base("Name=FoxTickContext")
		{
		}

        public DbSet<Ad> Ads { get; set; }
        public DbSet<Alert> Alerts { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<ClientAlert> ClientAlerts { get; set; }
        public DbSet<ClientGame> ClientGames { get; set; }
        public DbSet<ClientLog> ClientLogs { get; set; }
        public DbSet<ClientNetwork> ClientNetworks { get; set; }
        public DbSet<ClientNewsAlert> ClientNewsAlerts { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientSport> ClientSports { get; set; }
        public DbSet<ClientStatus> ClientStatuses { get; set; }
        public DbSet<ClientTeam> ClientTeams { get; set; }
        public DbSet<dtproperty> dtproperties { get; set; }
        public DbSet<EntryType> EntryTypes { get; set; }
        public DbSet<GameNote> GameNotes { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GameStat> GameStats { get; set; }
        public DbSet<GameStatus> GameStatuses { get; set; }
        public DbSet<GroupAnimationType> GroupAnimationTypes { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<ImporterLog> ImporterLogs { get; set; }
        public DbSet<Importer> Importers { get; set; }
        public DbSet<ManagementGameNote> ManagementGameNotes { get; set; }
        public DbSet<ManagementGame> ManagementGames { get; set; }
        public DbSet<MSdynamicsnapshotjob> MSdynamicsnapshotjobs { get; set; }
        public DbSet<MSdynamicsnapshotview> MSdynamicsnapshotviews { get; set; }
        public DbSet<MSmerge_agent_parameters> MSmerge_agent_parameters { get; set; }
        public DbSet<MSmerge_altsyncpartners> MSmerge_altsyncpartners { get; set; }
        public DbSet<MSmerge_articlehistory> MSmerge_articlehistory { get; set; }
        public DbSet<MSmerge_conflict_FoxTick_Ads> MSmerge_conflict_FoxTick_Ads { get; set; }
        public DbSet<MSmerge_conflict_FoxTick_Alerts> MSmerge_conflict_FoxTick_Alerts { get; set; }
        public DbSet<MSmerge_conflict_FoxTick_Banners> MSmerge_conflict_FoxTick_Banners { get; set; }
        public DbSet<MSmerge_conflict_FoxTick_ClientAlerts> MSmerge_conflict_FoxTick_ClientAlerts { get; set; }
        public DbSet<MSmerge_conflict_FoxTick_ClientGames> MSmerge_conflict_FoxTick_ClientGames { get; set; }
        public DbSet<MSmerge_conflict_FoxTick_ClientLogs> MSmerge_conflict_FoxTick_ClientLogs { get; set; }
        public DbSet<MSmerge_conflict_FoxTick_ClientNetworks> MSmerge_conflict_FoxTick_ClientNetworks { get; set; }
        public DbSet<MSmerge_conflict_FoxTick_ClientNewsAlerts> MSmerge_conflict_FoxTick_ClientNewsAlerts { get; set; }
        public DbSet<MSmerge_conflict_FoxTick_Clients> MSmerge_conflict_FoxTick_Clients { get; set; }
        public DbSet<MSmerge_conflict_FoxTick_ClientSports> MSmerge_conflict_FoxTick_ClientSports { get; set; }
        public DbSet<MSmerge_conflict_FoxTick_ClientStatuses> MSmerge_conflict_FoxTick_ClientStatuses { get; set; }
        public DbSet<MSmerge_conflict_FoxTick_ClientTeams> MSmerge_conflict_FoxTick_ClientTeams { get; set; }
        public DbSet<MSmerge_conflict_FoxTick_EntryTypes> MSmerge_conflict_FoxTick_EntryTypes { get; set; }
        public DbSet<MSmerge_conflict_FoxTick_GameNotes> MSmerge_conflict_FoxTick_GameNotes { get; set; }
        public DbSet<MSmerge_conflict_FoxTick_Games> MSmerge_conflict_FoxTick_Games { get; set; }
        public DbSet<MSmerge_conflict_FoxTick_GameStats> MSmerge_conflict_FoxTick_GameStats { get; set; }
        public DbSet<MSmerge_conflict_FoxTick_GameStatuses> MSmerge_conflict_FoxTick_GameStatuses { get; set; }
        public DbSet<MSmerge_conflict_FoxTick_GroupAnimationTypes> MSmerge_conflict_FoxTick_GroupAnimationTypes { get; set; }
        public DbSet<MSmerge_conflict_FoxTick_Groups> MSmerge_conflict_FoxTick_Groups { get; set; }
        public DbSet<MSmerge_conflict_FoxTick_ImporterLogs> MSmerge_conflict_FoxTick_ImporterLogs { get; set; }
        public DbSet<MSmerge_conflict_FoxTick_Importers> MSmerge_conflict_FoxTick_Importers { get; set; }
        public DbSet<MSmerge_conflict_FoxTick_ManagementGameNotes> MSmerge_conflict_FoxTick_ManagementGameNotes { get; set; }
        public DbSet<MSmerge_conflict_FoxTick_ManagementGames> MSmerge_conflict_FoxTick_ManagementGames { get; set; }
        public DbSet<MSmerge_conflict_FoxTick_Networks> MSmerge_conflict_FoxTick_Networks { get; set; }
        public DbSet<MSmerge_conflict_FoxTick_NewsAlerts> MSmerge_conflict_FoxTick_NewsAlerts { get; set; }
        public DbSet<MSmerge_conflict_FoxTick_NFLGameNotes> MSmerge_conflict_FoxTick_NFLGameNotes { get; set; }
        public DbSet<MSmerge_conflict_FoxTick_Notes> MSmerge_conflict_FoxTick_Notes { get; set; }
        public DbSet<MSmerge_conflict_FoxTick_Players> MSmerge_conflict_FoxTick_Players { get; set; }
        public DbSet<MSmerge_conflict_FoxTick_PlaylistDetails> MSmerge_conflict_FoxTick_PlaylistDetails { get; set; }
        public DbSet<MSmerge_conflict_FoxTick_Playlists> MSmerge_conflict_FoxTick_Playlists { get; set; }
        public DbSet<MSmerge_conflict_FoxTick_Sports> MSmerge_conflict_FoxTick_Sports { get; set; }
        public DbSet<MSmerge_conflict_FoxTick_Statuses> MSmerge_conflict_FoxTick_Statuses { get; set; }
        public DbSet<MSmerge_conflict_FoxTick_sysdiagrams> MSmerge_conflict_FoxTick_sysdiagrams { get; set; }
        public DbSet<MSmerge_conflict_FoxTick_Teams> MSmerge_conflict_FoxTick_Teams { get; set; }
        public DbSet<MSmerge_conflict_FoxTick_Users> MSmerge_conflict_FoxTick_Users { get; set; }
        public DbSet<MSmerge_conflicts_info> MSmerge_conflicts_info { get; set; }
        public DbSet<MSmerge_contents> MSmerge_contents { get; set; }
        public DbSet<MSmerge_current_partition_mappings> MSmerge_current_partition_mappings { get; set; }
        public DbSet<MSmerge_dynamic_snapshots> MSmerge_dynamic_snapshots { get; set; }
        public DbSet<MSmerge_errorlineage> MSmerge_errorlineage { get; set; }
        public DbSet<MSmerge_generation_partition_mappings> MSmerge_generation_partition_mappings { get; set; }
        public DbSet<MSmerge_genhistory> MSmerge_genhistory { get; set; }
        public DbSet<MSmerge_history> MSmerge_history { get; set; }
        public DbSet<MSmerge_identity_range> MSmerge_identity_range { get; set; }
        public DbSet<MSmerge_log_files> MSmerge_log_files { get; set; }
        public DbSet<MSmerge_metadataaction_request> MSmerge_metadataaction_request { get; set; }
        public DbSet<MSmerge_partition_groups> MSmerge_partition_groups { get; set; }
        public DbSet<MSmerge_past_partition_mappings> MSmerge_past_partition_mappings { get; set; }
        public DbSet<MSmerge_replinfo> MSmerge_replinfo { get; set; }
        public DbSet<MSmerge_sessions> MSmerge_sessions { get; set; }
        public DbSet<MSmerge_settingshistory> MSmerge_settingshistory { get; set; }
        public DbSet<MSmerge_supportability_settings> MSmerge_supportability_settings { get; set; }
        public DbSet<MSmerge_tombstone> MSmerge_tombstone { get; set; }
        public DbSet<MSrepl_errors> MSrepl_errors { get; set; }
        public DbSet<Network> Networks { get; set; }
        public DbSet<NewsAlert> NewsAlerts { get; set; }
        public DbSet<NFLGameNote> NFLGameNotes { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlaylistDetail> PlaylistDetails { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Sport> Sports { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<sysmergearticle> sysmergearticles { get; set; }
        public DbSet<sysmergepartitioninfo> sysmergepartitioninfoes { get; set; }
        public DbSet<sysmergepublication> sysmergepublications { get; set; }
        public DbSet<sysmergeschemaarticle> sysmergeschemaarticles { get; set; }
        public DbSet<sysmergeschemachange> sysmergeschemachanges { get; set; }
        public DbSet<sysmergesubscription> sysmergesubscriptions { get; set; }
        public DbSet<sysmergesubsetfilter> sysmergesubsetfilters { get; set; }
        public DbSet<sysreplserver> sysreplservers { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<MSmerge_ctsv_1BF552076F444AA98BA5A9B2B491BC60> MSmerge_ctsv_1BF552076F444AA98BA5A9B2B491BC60 { get; set; }
        public DbSet<MSmerge_ctsv_20B74CEDDD5243D78EFB2AC883C0C742> MSmerge_ctsv_20B74CEDDD5243D78EFB2AC883C0C742 { get; set; }
        public DbSet<MSmerge_ctsv_33177264FB40407F8F7985E30690406F> MSmerge_ctsv_33177264FB40407F8F7985E30690406F { get; set; }
        public DbSet<MSmerge_ctsv_3A27831AF4504C79AF0092DC4EAA0950> MSmerge_ctsv_3A27831AF4504C79AF0092DC4EAA0950 { get; set; }
        public DbSet<MSmerge_ctsv_3B616ECE40DE406EA2F8C8EA0C730823> MSmerge_ctsv_3B616ECE40DE406EA2F8C8EA0C730823 { get; set; }
        public DbSet<MSmerge_ctsv_3F91A991094D4AA48825BE7ABD3BBC0D> MSmerge_ctsv_3F91A991094D4AA48825BE7ABD3BBC0D { get; set; }
        public DbSet<MSmerge_ctsv_465E8B89A97340D08709A08B7B71A00A> MSmerge_ctsv_465E8B89A97340D08709A08B7B71A00A { get; set; }
        public DbSet<MSmerge_ctsv_467DC94C223349C6A0417F1FD7AF9E7B> MSmerge_ctsv_467DC94C223349C6A0417F1FD7AF9E7B { get; set; }
        public DbSet<MSmerge_ctsv_6652F91250544FAB9F2FFC8205704612> MSmerge_ctsv_6652F91250544FAB9F2FFC8205704612 { get; set; }
        public DbSet<MSmerge_ctsv_682A82085722461D932D23C14CC46688> MSmerge_ctsv_682A82085722461D932D23C14CC46688 { get; set; }
        public DbSet<MSmerge_ctsv_6B580F3E807943A3BA6BB0531C7E4E43> MSmerge_ctsv_6B580F3E807943A3BA6BB0531C7E4E43 { get; set; }
        public DbSet<MSmerge_ctsv_6C8A90F5829646DB940996D053BBCE9B> MSmerge_ctsv_6C8A90F5829646DB940996D053BBCE9B { get; set; }
        public DbSet<MSmerge_ctsv_6E6FC966139E429F86BA7566E3116F05> MSmerge_ctsv_6E6FC966139E429F86BA7566E3116F05 { get; set; }
        public DbSet<MSmerge_ctsv_7036411C9AC14250956EEFB8CBB8E877> MSmerge_ctsv_7036411C9AC14250956EEFB8CBB8E877 { get; set; }
        public DbSet<MSmerge_ctsv_73502D14121E4B75A4C01D824B03C0D3> MSmerge_ctsv_73502D14121E4B75A4C01D824B03C0D3 { get; set; }
        public DbSet<MSmerge_ctsv_74067179DBA4420580563202F4C416A3> MSmerge_ctsv_74067179DBA4420580563202F4C416A3 { get; set; }
        public DbSet<MSmerge_ctsv_741B26DBF528453481B23E906DB4465D> MSmerge_ctsv_741B26DBF528453481B23E906DB4465D { get; set; }
        public DbSet<MSmerge_ctsv_7973FE55EF8F480EBF7BC482250D7A47> MSmerge_ctsv_7973FE55EF8F480EBF7BC482250D7A47 { get; set; }
        public DbSet<MSmerge_ctsv_79B222F6368840A0BE11C3FD3C89ABB0> MSmerge_ctsv_79B222F6368840A0BE11C3FD3C89ABB0 { get; set; }
        public DbSet<MSmerge_ctsv_7EE304486F174938BDBAB19C2BE2D5A0> MSmerge_ctsv_7EE304486F174938BDBAB19C2BE2D5A0 { get; set; }
        public DbSet<MSmerge_ctsv_84B6FC92668D49B1A4C35D7543002859> MSmerge_ctsv_84B6FC92668D49B1A4C35D7543002859 { get; set; }
        public DbSet<MSmerge_ctsv_8742FFF2F37E4D6795415DF3B7C150A5> MSmerge_ctsv_8742FFF2F37E4D6795415DF3B7C150A5 { get; set; }
        public DbSet<MSmerge_ctsv_8A4E7D7BDA80410696CD2E002F04C6A3> MSmerge_ctsv_8A4E7D7BDA80410696CD2E002F04C6A3 { get; set; }
        public DbSet<MSmerge_ctsv_8AD88F8E6A9843E0887D9D133B582E49> MSmerge_ctsv_8AD88F8E6A9843E0887D9D133B582E49 { get; set; }
        public DbSet<MSmerge_ctsv_912E10792A1642B594FBBA0BD6585863> MSmerge_ctsv_912E10792A1642B594FBBA0BD6585863 { get; set; }
        public DbSet<MSmerge_ctsv_95BD04E007FC4F809C53B6B56F1FF5D0> MSmerge_ctsv_95BD04E007FC4F809C53B6B56F1FF5D0 { get; set; }
        public DbSet<MSmerge_ctsv_AF6A1B56B97547058295B125F28DED5E> MSmerge_ctsv_AF6A1B56B97547058295B125F28DED5E { get; set; }
        public DbSet<MSmerge_ctsv_B14C2C3EF4AD4E729E88E0F5E862E96E> MSmerge_ctsv_B14C2C3EF4AD4E729E88E0F5E862E96E { get; set; }
        public DbSet<MSmerge_ctsv_B34D66C5A09648778BE2364D1B50ED14> MSmerge_ctsv_B34D66C5A09648778BE2364D1B50ED14 { get; set; }
        public DbSet<MSmerge_ctsv_B93B4BF1EAA5447EB6A5F5B6827F41BF> MSmerge_ctsv_B93B4BF1EAA5447EB6A5F5B6827F41BF { get; set; }
        public DbSet<MSmerge_ctsv_C469A03675D841B9B14DE6B6BC35DA77> MSmerge_ctsv_C469A03675D841B9B14DE6B6BC35DA77 { get; set; }
        public DbSet<MSmerge_ctsv_D858916FB3774522B844FBFD6C117C68> MSmerge_ctsv_D858916FB3774522B844FBFD6C117C68 { get; set; }
        public DbSet<MSmerge_ctsv_DFAF17508C804EA186C353DE73055980> MSmerge_ctsv_DFAF17508C804EA186C353DE73055980 { get; set; }
        public DbSet<MSmerge_ctsv_E6E5B14B1F21410AB211FF7E4C85B272> MSmerge_ctsv_E6E5B14B1F21410AB211FF7E4C85B272 { get; set; }
        public DbSet<MSmerge_ctsv_F9D70570176F45A79E27B75A427B83AB> MSmerge_ctsv_F9D70570176F45A79E27B75A427B83AB { get; set; }
        public DbSet<MSmerge_FoxTick_Ads_VIEW> MSmerge_FoxTick_Ads_VIEW { get; set; }
        public DbSet<MSmerge_FoxTick_Alerts_VIEW> MSmerge_FoxTick_Alerts_VIEW { get; set; }
        public DbSet<MSmerge_FoxTick_Banners_VIEW> MSmerge_FoxTick_Banners_VIEW { get; set; }
        public DbSet<MSmerge_FoxTick_ClientAlerts_VIEW> MSmerge_FoxTick_ClientAlerts_VIEW { get; set; }
        public DbSet<MSmerge_FoxTick_ClientGames_VIEW> MSmerge_FoxTick_ClientGames_VIEW { get; set; }
        public DbSet<MSmerge_FoxTick_ClientLogs_VIEW> MSmerge_FoxTick_ClientLogs_VIEW { get; set; }
        public DbSet<MSmerge_FoxTick_ClientNetworks_VIEW> MSmerge_FoxTick_ClientNetworks_VIEW { get; set; }
        public DbSet<MSmerge_FoxTick_ClientNewsAlerts_VIEW> MSmerge_FoxTick_ClientNewsAlerts_VIEW { get; set; }
        public DbSet<MSmerge_FoxTick_Clients_VIEW> MSmerge_FoxTick_Clients_VIEW { get; set; }
        public DbSet<MSmerge_FoxTick_ClientSports_VIEW> MSmerge_FoxTick_ClientSports_VIEW { get; set; }
        public DbSet<MSmerge_FoxTick_ClientStatuses_VIEW> MSmerge_FoxTick_ClientStatuses_VIEW { get; set; }
        public DbSet<MSmerge_FoxTick_ClientTeams_VIEW> MSmerge_FoxTick_ClientTeams_VIEW { get; set; }
        public DbSet<MSmerge_FoxTick_EntryTypes_VIEW> MSmerge_FoxTick_EntryTypes_VIEW { get; set; }
        public DbSet<MSmerge_FoxTick_GameNotes_VIEW> MSmerge_FoxTick_GameNotes_VIEW { get; set; }
        public DbSet<MSmerge_FoxTick_Games_VIEW> MSmerge_FoxTick_Games_VIEW { get; set; }
        public DbSet<MSmerge_FoxTick_GameStats_VIEW> MSmerge_FoxTick_GameStats_VIEW { get; set; }
        public DbSet<MSmerge_FoxTick_GameStatuses_VIEW> MSmerge_FoxTick_GameStatuses_VIEW { get; set; }
        public DbSet<MSmerge_FoxTick_GroupAnimationTypes_VIEW> MSmerge_FoxTick_GroupAnimationTypes_VIEW { get; set; }
        public DbSet<MSmerge_FoxTick_Groups_VIEW> MSmerge_FoxTick_Groups_VIEW { get; set; }
        public DbSet<MSmerge_FoxTick_ImporterLogs_VIEW> MSmerge_FoxTick_ImporterLogs_VIEW { get; set; }
        public DbSet<MSmerge_FoxTick_Importers_VIEW> MSmerge_FoxTick_Importers_VIEW { get; set; }
        public DbSet<MSmerge_FoxTick_ManagementGameNotes_VIEW> MSmerge_FoxTick_ManagementGameNotes_VIEW { get; set; }
        public DbSet<MSmerge_FoxTick_ManagementGames_VIEW> MSmerge_FoxTick_ManagementGames_VIEW { get; set; }
        public DbSet<MSmerge_FoxTick_Networks_VIEW> MSmerge_FoxTick_Networks_VIEW { get; set; }
        public DbSet<MSmerge_FoxTick_NewsAlerts_VIEW> MSmerge_FoxTick_NewsAlerts_VIEW { get; set; }
        public DbSet<MSmerge_FoxTick_NFLGameNotes_VIEW> MSmerge_FoxTick_NFLGameNotes_VIEW { get; set; }
        public DbSet<MSmerge_FoxTick_Notes_VIEW> MSmerge_FoxTick_Notes_VIEW { get; set; }
        public DbSet<MSmerge_FoxTick_Players_VIEW> MSmerge_FoxTick_Players_VIEW { get; set; }
        public DbSet<MSmerge_FoxTick_PlaylistDetails_VIEW> MSmerge_FoxTick_PlaylistDetails_VIEW { get; set; }
        public DbSet<MSmerge_FoxTick_Playlists_VIEW> MSmerge_FoxTick_Playlists_VIEW { get; set; }
        public DbSet<MSmerge_FoxTick_Sports_VIEW> MSmerge_FoxTick_Sports_VIEW { get; set; }
        public DbSet<MSmerge_FoxTick_Statuses_VIEW> MSmerge_FoxTick_Statuses_VIEW { get; set; }
        public DbSet<MSmerge_FoxTick_sysdiagrams_VIEW> MSmerge_FoxTick_sysdiagrams_VIEW { get; set; }
        public DbSet<MSmerge_FoxTick_Teams_VIEW> MSmerge_FoxTick_Teams_VIEW { get; set; }
        public DbSet<MSmerge_FoxTick_Users_VIEW> MSmerge_FoxTick_Users_VIEW { get; set; }
        public DbSet<MSmerge_genvw_1BF552076F444AA98BA5A9B2B491BC60> MSmerge_genvw_1BF552076F444AA98BA5A9B2B491BC60 { get; set; }
        public DbSet<MSmerge_genvw_20B74CEDDD5243D78EFB2AC883C0C742> MSmerge_genvw_20B74CEDDD5243D78EFB2AC883C0C742 { get; set; }
        public DbSet<MSmerge_genvw_33177264FB40407F8F7985E30690406F> MSmerge_genvw_33177264FB40407F8F7985E30690406F { get; set; }
        public DbSet<MSmerge_genvw_3A27831AF4504C79AF0092DC4EAA0950> MSmerge_genvw_3A27831AF4504C79AF0092DC4EAA0950 { get; set; }
        public DbSet<MSmerge_genvw_3B616ECE40DE406EA2F8C8EA0C730823> MSmerge_genvw_3B616ECE40DE406EA2F8C8EA0C730823 { get; set; }
        public DbSet<MSmerge_genvw_3F91A991094D4AA48825BE7ABD3BBC0D> MSmerge_genvw_3F91A991094D4AA48825BE7ABD3BBC0D { get; set; }
        public DbSet<MSmerge_genvw_465E8B89A97340D08709A08B7B71A00A> MSmerge_genvw_465E8B89A97340D08709A08B7B71A00A { get; set; }
        public DbSet<MSmerge_genvw_467DC94C223349C6A0417F1FD7AF9E7B> MSmerge_genvw_467DC94C223349C6A0417F1FD7AF9E7B { get; set; }
        public DbSet<MSmerge_genvw_6652F91250544FAB9F2FFC8205704612> MSmerge_genvw_6652F91250544FAB9F2FFC8205704612 { get; set; }
        public DbSet<MSmerge_genvw_682A82085722461D932D23C14CC46688> MSmerge_genvw_682A82085722461D932D23C14CC46688 { get; set; }
        public DbSet<MSmerge_genvw_6B580F3E807943A3BA6BB0531C7E4E43> MSmerge_genvw_6B580F3E807943A3BA6BB0531C7E4E43 { get; set; }
        public DbSet<MSmerge_genvw_6C8A90F5829646DB940996D053BBCE9B> MSmerge_genvw_6C8A90F5829646DB940996D053BBCE9B { get; set; }
        public DbSet<MSmerge_genvw_6E6FC966139E429F86BA7566E3116F05> MSmerge_genvw_6E6FC966139E429F86BA7566E3116F05 { get; set; }
        public DbSet<MSmerge_genvw_7036411C9AC14250956EEFB8CBB8E877> MSmerge_genvw_7036411C9AC14250956EEFB8CBB8E877 { get; set; }
        public DbSet<MSmerge_genvw_73502D14121E4B75A4C01D824B03C0D3> MSmerge_genvw_73502D14121E4B75A4C01D824B03C0D3 { get; set; }
        public DbSet<MSmerge_genvw_74067179DBA4420580563202F4C416A3> MSmerge_genvw_74067179DBA4420580563202F4C416A3 { get; set; }
        public DbSet<MSmerge_genvw_741B26DBF528453481B23E906DB4465D> MSmerge_genvw_741B26DBF528453481B23E906DB4465D { get; set; }
        public DbSet<MSmerge_genvw_7973FE55EF8F480EBF7BC482250D7A47> MSmerge_genvw_7973FE55EF8F480EBF7BC482250D7A47 { get; set; }
        public DbSet<MSmerge_genvw_79B222F6368840A0BE11C3FD3C89ABB0> MSmerge_genvw_79B222F6368840A0BE11C3FD3C89ABB0 { get; set; }
        public DbSet<MSmerge_genvw_7EE304486F174938BDBAB19C2BE2D5A0> MSmerge_genvw_7EE304486F174938BDBAB19C2BE2D5A0 { get; set; }
        public DbSet<MSmerge_genvw_84B6FC92668D49B1A4C35D7543002859> MSmerge_genvw_84B6FC92668D49B1A4C35D7543002859 { get; set; }
        public DbSet<MSmerge_genvw_8742FFF2F37E4D6795415DF3B7C150A5> MSmerge_genvw_8742FFF2F37E4D6795415DF3B7C150A5 { get; set; }
        public DbSet<MSmerge_genvw_8A4E7D7BDA80410696CD2E002F04C6A3> MSmerge_genvw_8A4E7D7BDA80410696CD2E002F04C6A3 { get; set; }
        public DbSet<MSmerge_genvw_8AD88F8E6A9843E0887D9D133B582E49> MSmerge_genvw_8AD88F8E6A9843E0887D9D133B582E49 { get; set; }
        public DbSet<MSmerge_genvw_912E10792A1642B594FBBA0BD6585863> MSmerge_genvw_912E10792A1642B594FBBA0BD6585863 { get; set; }
        public DbSet<MSmerge_genvw_95BD04E007FC4F809C53B6B56F1FF5D0> MSmerge_genvw_95BD04E007FC4F809C53B6B56F1FF5D0 { get; set; }
        public DbSet<MSmerge_genvw_AF6A1B56B97547058295B125F28DED5E> MSmerge_genvw_AF6A1B56B97547058295B125F28DED5E { get; set; }
        public DbSet<MSmerge_genvw_B14C2C3EF4AD4E729E88E0F5E862E96E> MSmerge_genvw_B14C2C3EF4AD4E729E88E0F5E862E96E { get; set; }
        public DbSet<MSmerge_genvw_B34D66C5A09648778BE2364D1B50ED14> MSmerge_genvw_B34D66C5A09648778BE2364D1B50ED14 { get; set; }
        public DbSet<MSmerge_genvw_B93B4BF1EAA5447EB6A5F5B6827F41BF> MSmerge_genvw_B93B4BF1EAA5447EB6A5F5B6827F41BF { get; set; }
        public DbSet<MSmerge_genvw_C469A03675D841B9B14DE6B6BC35DA77> MSmerge_genvw_C469A03675D841B9B14DE6B6BC35DA77 { get; set; }
        public DbSet<MSmerge_genvw_D858916FB3774522B844FBFD6C117C68> MSmerge_genvw_D858916FB3774522B844FBFD6C117C68 { get; set; }
        public DbSet<MSmerge_genvw_DFAF17508C804EA186C353DE73055980> MSmerge_genvw_DFAF17508C804EA186C353DE73055980 { get; set; }
        public DbSet<MSmerge_genvw_E6E5B14B1F21410AB211FF7E4C85B272> MSmerge_genvw_E6E5B14B1F21410AB211FF7E4C85B272 { get; set; }
        public DbSet<MSmerge_genvw_F9D70570176F45A79E27B75A427B83AB> MSmerge_genvw_F9D70570176F45A79E27B75A427B83AB { get; set; }
        public DbSet<MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_1BF552076F444AA98BA5A9B2B491BC60> MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_1BF552076F444AA98BA5A9B2B491BC60 { get; set; }
        public DbSet<MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_20B74CEDDD5243D78EFB2AC883C0C742> MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_20B74CEDDD5243D78EFB2AC883C0C742 { get; set; }
        public DbSet<MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_33177264FB40407F8F7985E30690406F> MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_33177264FB40407F8F7985E30690406F { get; set; }
        public DbSet<MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_3A27831AF4504C79AF0092DC4EAA0950> MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_3A27831AF4504C79AF0092DC4EAA0950 { get; set; }
        public DbSet<MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_3B616ECE40DE406EA2F8C8EA0C730823> MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_3B616ECE40DE406EA2F8C8EA0C730823 { get; set; }
        public DbSet<MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_3F91A991094D4AA48825BE7ABD3BBC0D> MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_3F91A991094D4AA48825BE7ABD3BBC0D { get; set; }
        public DbSet<MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_465E8B89A97340D08709A08B7B71A00A> MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_465E8B89A97340D08709A08B7B71A00A { get; set; }
        public DbSet<MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_467DC94C223349C6A0417F1FD7AF9E7B> MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_467DC94C223349C6A0417F1FD7AF9E7B { get; set; }
        public DbSet<MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_6652F91250544FAB9F2FFC8205704612> MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_6652F91250544FAB9F2FFC8205704612 { get; set; }
        public DbSet<MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_682A82085722461D932D23C14CC46688> MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_682A82085722461D932D23C14CC46688 { get; set; }
        public DbSet<MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_6B580F3E807943A3BA6BB0531C7E4E43> MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_6B580F3E807943A3BA6BB0531C7E4E43 { get; set; }
        public DbSet<MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_6C8A90F5829646DB940996D053BBCE9B> MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_6C8A90F5829646DB940996D053BBCE9B { get; set; }
        public DbSet<MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_6E6FC966139E429F86BA7566E3116F05> MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_6E6FC966139E429F86BA7566E3116F05 { get; set; }
        public DbSet<MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_7036411C9AC14250956EEFB8CBB8E877> MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_7036411C9AC14250956EEFB8CBB8E877 { get; set; }
        public DbSet<MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_73502D14121E4B75A4C01D824B03C0D3> MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_73502D14121E4B75A4C01D824B03C0D3 { get; set; }
        public DbSet<MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_74067179DBA4420580563202F4C416A3> MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_74067179DBA4420580563202F4C416A3 { get; set; }
        public DbSet<MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_741B26DBF528453481B23E906DB4465D> MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_741B26DBF528453481B23E906DB4465D { get; set; }
        public DbSet<MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_7973FE55EF8F480EBF7BC482250D7A47> MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_7973FE55EF8F480EBF7BC482250D7A47 { get; set; }
        public DbSet<MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_79B222F6368840A0BE11C3FD3C89ABB0> MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_79B222F6368840A0BE11C3FD3C89ABB0 { get; set; }
        public DbSet<MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_7EE304486F174938BDBAB19C2BE2D5A0> MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_7EE304486F174938BDBAB19C2BE2D5A0 { get; set; }
        public DbSet<MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_84B6FC92668D49B1A4C35D7543002859> MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_84B6FC92668D49B1A4C35D7543002859 { get; set; }
        public DbSet<MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_8742FFF2F37E4D6795415DF3B7C150A5> MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_8742FFF2F37E4D6795415DF3B7C150A5 { get; set; }
        public DbSet<MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_8A4E7D7BDA80410696CD2E002F04C6A3> MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_8A4E7D7BDA80410696CD2E002F04C6A3 { get; set; }
        public DbSet<MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_8AD88F8E6A9843E0887D9D133B582E49> MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_8AD88F8E6A9843E0887D9D133B582E49 { get; set; }
        public DbSet<MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_912E10792A1642B594FBBA0BD6585863> MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_912E10792A1642B594FBBA0BD6585863 { get; set; }
        public DbSet<MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_95BD04E007FC4F809C53B6B56F1FF5D0> MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_95BD04E007FC4F809C53B6B56F1FF5D0 { get; set; }
        public DbSet<MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_AF6A1B56B97547058295B125F28DED5E> MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_AF6A1B56B97547058295B125F28DED5E { get; set; }
        public DbSet<MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_B14C2C3EF4AD4E729E88E0F5E862E96E> MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_B14C2C3EF4AD4E729E88E0F5E862E96E { get; set; }
        public DbSet<MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_B34D66C5A09648778BE2364D1B50ED14> MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_B34D66C5A09648778BE2364D1B50ED14 { get; set; }
        public DbSet<MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_B93B4BF1EAA5447EB6A5F5B6827F41BF> MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_B93B4BF1EAA5447EB6A5F5B6827F41BF { get; set; }
        public DbSet<MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_C469A03675D841B9B14DE6B6BC35DA77> MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_C469A03675D841B9B14DE6B6BC35DA77 { get; set; }
        public DbSet<MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_D858916FB3774522B844FBFD6C117C68> MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_D858916FB3774522B844FBFD6C117C68 { get; set; }
        public DbSet<MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_DFAF17508C804EA186C353DE73055980> MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_DFAF17508C804EA186C353DE73055980 { get; set; }
        public DbSet<MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_E6E5B14B1F21410AB211FF7E4C85B272> MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_E6E5B14B1F21410AB211FF7E4C85B272 { get; set; }
        public DbSet<MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_F9D70570176F45A79E27B75A427B83AB> MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_F9D70570176F45A79E27B75A427B83AB { get; set; }
        public DbSet<MSmerge_tsvw_1BF552076F444AA98BA5A9B2B491BC60> MSmerge_tsvw_1BF552076F444AA98BA5A9B2B491BC60 { get; set; }
        public DbSet<MSmerge_tsvw_20B74CEDDD5243D78EFB2AC883C0C742> MSmerge_tsvw_20B74CEDDD5243D78EFB2AC883C0C742 { get; set; }
        public DbSet<MSmerge_tsvw_33177264FB40407F8F7985E30690406F> MSmerge_tsvw_33177264FB40407F8F7985E30690406F { get; set; }
        public DbSet<MSmerge_tsvw_3A27831AF4504C79AF0092DC4EAA0950> MSmerge_tsvw_3A27831AF4504C79AF0092DC4EAA0950 { get; set; }
        public DbSet<MSmerge_tsvw_3B616ECE40DE406EA2F8C8EA0C730823> MSmerge_tsvw_3B616ECE40DE406EA2F8C8EA0C730823 { get; set; }
        public DbSet<MSmerge_tsvw_3F91A991094D4AA48825BE7ABD3BBC0D> MSmerge_tsvw_3F91A991094D4AA48825BE7ABD3BBC0D { get; set; }
        public DbSet<MSmerge_tsvw_465E8B89A97340D08709A08B7B71A00A> MSmerge_tsvw_465E8B89A97340D08709A08B7B71A00A { get; set; }
        public DbSet<MSmerge_tsvw_467DC94C223349C6A0417F1FD7AF9E7B> MSmerge_tsvw_467DC94C223349C6A0417F1FD7AF9E7B { get; set; }
        public DbSet<MSmerge_tsvw_6652F91250544FAB9F2FFC8205704612> MSmerge_tsvw_6652F91250544FAB9F2FFC8205704612 { get; set; }
        public DbSet<MSmerge_tsvw_682A82085722461D932D23C14CC46688> MSmerge_tsvw_682A82085722461D932D23C14CC46688 { get; set; }
        public DbSet<MSmerge_tsvw_6B580F3E807943A3BA6BB0531C7E4E43> MSmerge_tsvw_6B580F3E807943A3BA6BB0531C7E4E43 { get; set; }
        public DbSet<MSmerge_tsvw_6C8A90F5829646DB940996D053BBCE9B> MSmerge_tsvw_6C8A90F5829646DB940996D053BBCE9B { get; set; }
        public DbSet<MSmerge_tsvw_6E6FC966139E429F86BA7566E3116F05> MSmerge_tsvw_6E6FC966139E429F86BA7566E3116F05 { get; set; }
        public DbSet<MSmerge_tsvw_7036411C9AC14250956EEFB8CBB8E877> MSmerge_tsvw_7036411C9AC14250956EEFB8CBB8E877 { get; set; }
        public DbSet<MSmerge_tsvw_73502D14121E4B75A4C01D824B03C0D3> MSmerge_tsvw_73502D14121E4B75A4C01D824B03C0D3 { get; set; }
        public DbSet<MSmerge_tsvw_74067179DBA4420580563202F4C416A3> MSmerge_tsvw_74067179DBA4420580563202F4C416A3 { get; set; }
        public DbSet<MSmerge_tsvw_741B26DBF528453481B23E906DB4465D> MSmerge_tsvw_741B26DBF528453481B23E906DB4465D { get; set; }
        public DbSet<MSmerge_tsvw_7973FE55EF8F480EBF7BC482250D7A47> MSmerge_tsvw_7973FE55EF8F480EBF7BC482250D7A47 { get; set; }
        public DbSet<MSmerge_tsvw_79B222F6368840A0BE11C3FD3C89ABB0> MSmerge_tsvw_79B222F6368840A0BE11C3FD3C89ABB0 { get; set; }
        public DbSet<MSmerge_tsvw_7EE304486F174938BDBAB19C2BE2D5A0> MSmerge_tsvw_7EE304486F174938BDBAB19C2BE2D5A0 { get; set; }
        public DbSet<MSmerge_tsvw_84B6FC92668D49B1A4C35D7543002859> MSmerge_tsvw_84B6FC92668D49B1A4C35D7543002859 { get; set; }
        public DbSet<MSmerge_tsvw_8742FFF2F37E4D6795415DF3B7C150A5> MSmerge_tsvw_8742FFF2F37E4D6795415DF3B7C150A5 { get; set; }
        public DbSet<MSmerge_tsvw_8A4E7D7BDA80410696CD2E002F04C6A3> MSmerge_tsvw_8A4E7D7BDA80410696CD2E002F04C6A3 { get; set; }
        public DbSet<MSmerge_tsvw_8AD88F8E6A9843E0887D9D133B582E49> MSmerge_tsvw_8AD88F8E6A9843E0887D9D133B582E49 { get; set; }
        public DbSet<MSmerge_tsvw_912E10792A1642B594FBBA0BD6585863> MSmerge_tsvw_912E10792A1642B594FBBA0BD6585863 { get; set; }
        public DbSet<MSmerge_tsvw_95BD04E007FC4F809C53B6B56F1FF5D0> MSmerge_tsvw_95BD04E007FC4F809C53B6B56F1FF5D0 { get; set; }
        public DbSet<MSmerge_tsvw_AF6A1B56B97547058295B125F28DED5E> MSmerge_tsvw_AF6A1B56B97547058295B125F28DED5E { get; set; }
        public DbSet<MSmerge_tsvw_B14C2C3EF4AD4E729E88E0F5E862E96E> MSmerge_tsvw_B14C2C3EF4AD4E729E88E0F5E862E96E { get; set; }
        public DbSet<MSmerge_tsvw_B34D66C5A09648778BE2364D1B50ED14> MSmerge_tsvw_B34D66C5A09648778BE2364D1B50ED14 { get; set; }
        public DbSet<MSmerge_tsvw_B93B4BF1EAA5447EB6A5F5B6827F41BF> MSmerge_tsvw_B93B4BF1EAA5447EB6A5F5B6827F41BF { get; set; }
        public DbSet<MSmerge_tsvw_C469A03675D841B9B14DE6B6BC35DA77> MSmerge_tsvw_C469A03675D841B9B14DE6B6BC35DA77 { get; set; }
        public DbSet<MSmerge_tsvw_D858916FB3774522B844FBFD6C117C68> MSmerge_tsvw_D858916FB3774522B844FBFD6C117C68 { get; set; }
        public DbSet<MSmerge_tsvw_DFAF17508C804EA186C353DE73055980> MSmerge_tsvw_DFAF17508C804EA186C353DE73055980 { get; set; }
        public DbSet<MSmerge_tsvw_E6E5B14B1F21410AB211FF7E4C85B272> MSmerge_tsvw_E6E5B14B1F21410AB211FF7E4C85B272 { get; set; }
        public DbSet<MSmerge_tsvw_F9D70570176F45A79E27B75A427B83AB> MSmerge_tsvw_F9D70570176F45A79E27B75A427B83AB { get; set; }
        public DbSet<sysmergeextendedarticlesview> sysmergeextendedarticlesviews { get; set; }
        public DbSet<sysmergepartitioninfoview> sysmergepartitioninfoviews { get; set; }
        public DbSet<vwGamesCFB> vwGamesCFBs { get; set; }
        public DbSet<vwNCAA_TeamTranslate> vwNCAA_TeamTranslate { get; set; }
        public DbSet<vwOnAirNamesFSP> vwOnAirNamesFSPs { get; set; }
        public DbSet<vwTEMP_SoccerLeaders> vwTEMP_SoccerLeaders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AdMap());
            modelBuilder.Configurations.Add(new AlertMap());
            modelBuilder.Configurations.Add(new BannerMap());
            modelBuilder.Configurations.Add(new ClientAlertMap());
            modelBuilder.Configurations.Add(new ClientGameMap());
            modelBuilder.Configurations.Add(new ClientLogMap());
            modelBuilder.Configurations.Add(new ClientNetworkMap());
            modelBuilder.Configurations.Add(new ClientNewsAlertMap());
            modelBuilder.Configurations.Add(new ClientMap());
            modelBuilder.Configurations.Add(new ClientSportMap());
            modelBuilder.Configurations.Add(new ClientStatusMap());
            modelBuilder.Configurations.Add(new ClientTeamMap());
            modelBuilder.Configurations.Add(new dtpropertyMap());
            modelBuilder.Configurations.Add(new EntryTypeMap());
            modelBuilder.Configurations.Add(new GameNoteMap());
            modelBuilder.Configurations.Add(new GameMap());
            modelBuilder.Configurations.Add(new GameStatMap());
            modelBuilder.Configurations.Add(new GameStatusMap());
            modelBuilder.Configurations.Add(new GroupAnimationTypeMap());
            modelBuilder.Configurations.Add(new GroupMap());
            modelBuilder.Configurations.Add(new ImporterLogMap());
            modelBuilder.Configurations.Add(new ImporterMap());
            modelBuilder.Configurations.Add(new ManagementGameNoteMap());
            modelBuilder.Configurations.Add(new ManagementGameMap());
            modelBuilder.Configurations.Add(new MSdynamicsnapshotjobMap());
            modelBuilder.Configurations.Add(new MSdynamicsnapshotviewMap());
            modelBuilder.Configurations.Add(new MSmerge_agent_parametersMap());
            modelBuilder.Configurations.Add(new MSmerge_altsyncpartnersMap());
            modelBuilder.Configurations.Add(new MSmerge_articlehistoryMap());
            modelBuilder.Configurations.Add(new MSmerge_conflict_FoxTick_AdsMap());
            modelBuilder.Configurations.Add(new MSmerge_conflict_FoxTick_AlertsMap());
            modelBuilder.Configurations.Add(new MSmerge_conflict_FoxTick_BannersMap());
            modelBuilder.Configurations.Add(new MSmerge_conflict_FoxTick_ClientAlertsMap());
            modelBuilder.Configurations.Add(new MSmerge_conflict_FoxTick_ClientGamesMap());
            modelBuilder.Configurations.Add(new MSmerge_conflict_FoxTick_ClientLogsMap());
            modelBuilder.Configurations.Add(new MSmerge_conflict_FoxTick_ClientNetworksMap());
            modelBuilder.Configurations.Add(new MSmerge_conflict_FoxTick_ClientNewsAlertsMap());
            modelBuilder.Configurations.Add(new MSmerge_conflict_FoxTick_ClientsMap());
            modelBuilder.Configurations.Add(new MSmerge_conflict_FoxTick_ClientSportsMap());
            modelBuilder.Configurations.Add(new MSmerge_conflict_FoxTick_ClientStatusesMap());
            modelBuilder.Configurations.Add(new MSmerge_conflict_FoxTick_ClientTeamsMap());
            modelBuilder.Configurations.Add(new MSmerge_conflict_FoxTick_EntryTypesMap());
            modelBuilder.Configurations.Add(new MSmerge_conflict_FoxTick_GameNotesMap());
            modelBuilder.Configurations.Add(new MSmerge_conflict_FoxTick_GamesMap());
            modelBuilder.Configurations.Add(new MSmerge_conflict_FoxTick_GameStatsMap());
            modelBuilder.Configurations.Add(new MSmerge_conflict_FoxTick_GameStatusesMap());
            modelBuilder.Configurations.Add(new MSmerge_conflict_FoxTick_GroupAnimationTypesMap());
            modelBuilder.Configurations.Add(new MSmerge_conflict_FoxTick_GroupsMap());
            modelBuilder.Configurations.Add(new MSmerge_conflict_FoxTick_ImporterLogsMap());
            modelBuilder.Configurations.Add(new MSmerge_conflict_FoxTick_ImportersMap());
            modelBuilder.Configurations.Add(new MSmerge_conflict_FoxTick_ManagementGameNotesMap());
            modelBuilder.Configurations.Add(new MSmerge_conflict_FoxTick_ManagementGamesMap());
            modelBuilder.Configurations.Add(new MSmerge_conflict_FoxTick_NetworksMap());
            modelBuilder.Configurations.Add(new MSmerge_conflict_FoxTick_NewsAlertsMap());
            modelBuilder.Configurations.Add(new MSmerge_conflict_FoxTick_NFLGameNotesMap());
            modelBuilder.Configurations.Add(new MSmerge_conflict_FoxTick_NotesMap());
            modelBuilder.Configurations.Add(new MSmerge_conflict_FoxTick_PlayersMap());
            modelBuilder.Configurations.Add(new MSmerge_conflict_FoxTick_PlaylistDetailsMap());
            modelBuilder.Configurations.Add(new MSmerge_conflict_FoxTick_PlaylistsMap());
            modelBuilder.Configurations.Add(new MSmerge_conflict_FoxTick_SportsMap());
            modelBuilder.Configurations.Add(new MSmerge_conflict_FoxTick_StatusesMap());
            modelBuilder.Configurations.Add(new MSmerge_conflict_FoxTick_sysdiagramsMap());
            modelBuilder.Configurations.Add(new MSmerge_conflict_FoxTick_TeamsMap());
            modelBuilder.Configurations.Add(new MSmerge_conflict_FoxTick_UsersMap());
            modelBuilder.Configurations.Add(new MSmerge_conflicts_infoMap());
            modelBuilder.Configurations.Add(new MSmerge_contentsMap());
            modelBuilder.Configurations.Add(new MSmerge_current_partition_mappingsMap());
            modelBuilder.Configurations.Add(new MSmerge_dynamic_snapshotsMap());
            modelBuilder.Configurations.Add(new MSmerge_errorlineageMap());
            modelBuilder.Configurations.Add(new MSmerge_generation_partition_mappingsMap());
            modelBuilder.Configurations.Add(new MSmerge_genhistoryMap());
            modelBuilder.Configurations.Add(new MSmerge_historyMap());
            modelBuilder.Configurations.Add(new MSmerge_identity_rangeMap());
            modelBuilder.Configurations.Add(new MSmerge_log_filesMap());
            modelBuilder.Configurations.Add(new MSmerge_metadataaction_requestMap());
            modelBuilder.Configurations.Add(new MSmerge_partition_groupsMap());
            modelBuilder.Configurations.Add(new MSmerge_past_partition_mappingsMap());
            modelBuilder.Configurations.Add(new MSmerge_replinfoMap());
            modelBuilder.Configurations.Add(new MSmerge_sessionsMap());
            modelBuilder.Configurations.Add(new MSmerge_settingshistoryMap());
            modelBuilder.Configurations.Add(new MSmerge_supportability_settingsMap());
            modelBuilder.Configurations.Add(new MSmerge_tombstoneMap());
            modelBuilder.Configurations.Add(new MSrepl_errorsMap());
            modelBuilder.Configurations.Add(new NetworkMap());
            modelBuilder.Configurations.Add(new NewsAlertMap());
            modelBuilder.Configurations.Add(new NFLGameNoteMap());
            modelBuilder.Configurations.Add(new NoteMap());
            modelBuilder.Configurations.Add(new PlayerMap());
            modelBuilder.Configurations.Add(new PlaylistDetailMap());
            modelBuilder.Configurations.Add(new PlaylistMap());
            modelBuilder.Configurations.Add(new SportMap());
            modelBuilder.Configurations.Add(new StatusMap());
            modelBuilder.Configurations.Add(new sysdiagramMap());
            modelBuilder.Configurations.Add(new sysmergearticleMap());
            modelBuilder.Configurations.Add(new sysmergepartitioninfoMap());
            modelBuilder.Configurations.Add(new sysmergepublicationMap());
            modelBuilder.Configurations.Add(new sysmergeschemaarticleMap());
            modelBuilder.Configurations.Add(new sysmergeschemachangeMap());
            modelBuilder.Configurations.Add(new sysmergesubscriptionMap());
            modelBuilder.Configurations.Add(new sysmergesubsetfilterMap());
            modelBuilder.Configurations.Add(new sysreplserverMap());
            modelBuilder.Configurations.Add(new TeamMap());
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new MSmerge_ctsv_1BF552076F444AA98BA5A9B2B491BC60Map());
            modelBuilder.Configurations.Add(new MSmerge_ctsv_20B74CEDDD5243D78EFB2AC883C0C742Map());
            modelBuilder.Configurations.Add(new MSmerge_ctsv_33177264FB40407F8F7985E30690406FMap());
            modelBuilder.Configurations.Add(new MSmerge_ctsv_3A27831AF4504C79AF0092DC4EAA0950Map());
            modelBuilder.Configurations.Add(new MSmerge_ctsv_3B616ECE40DE406EA2F8C8EA0C730823Map());
            modelBuilder.Configurations.Add(new MSmerge_ctsv_3F91A991094D4AA48825BE7ABD3BBC0DMap());
            modelBuilder.Configurations.Add(new MSmerge_ctsv_465E8B89A97340D08709A08B7B71A00AMap());
            modelBuilder.Configurations.Add(new MSmerge_ctsv_467DC94C223349C6A0417F1FD7AF9E7BMap());
            modelBuilder.Configurations.Add(new MSmerge_ctsv_6652F91250544FAB9F2FFC8205704612Map());
            modelBuilder.Configurations.Add(new MSmerge_ctsv_682A82085722461D932D23C14CC46688Map());
            modelBuilder.Configurations.Add(new MSmerge_ctsv_6B580F3E807943A3BA6BB0531C7E4E43Map());
            modelBuilder.Configurations.Add(new MSmerge_ctsv_6C8A90F5829646DB940996D053BBCE9BMap());
            modelBuilder.Configurations.Add(new MSmerge_ctsv_6E6FC966139E429F86BA7566E3116F05Map());
            modelBuilder.Configurations.Add(new MSmerge_ctsv_7036411C9AC14250956EEFB8CBB8E877Map());
            modelBuilder.Configurations.Add(new MSmerge_ctsv_73502D14121E4B75A4C01D824B03C0D3Map());
            modelBuilder.Configurations.Add(new MSmerge_ctsv_74067179DBA4420580563202F4C416A3Map());
            modelBuilder.Configurations.Add(new MSmerge_ctsv_741B26DBF528453481B23E906DB4465DMap());
            modelBuilder.Configurations.Add(new MSmerge_ctsv_7973FE55EF8F480EBF7BC482250D7A47Map());
            modelBuilder.Configurations.Add(new MSmerge_ctsv_79B222F6368840A0BE11C3FD3C89ABB0Map());
            modelBuilder.Configurations.Add(new MSmerge_ctsv_7EE304486F174938BDBAB19C2BE2D5A0Map());
            modelBuilder.Configurations.Add(new MSmerge_ctsv_84B6FC92668D49B1A4C35D7543002859Map());
            modelBuilder.Configurations.Add(new MSmerge_ctsv_8742FFF2F37E4D6795415DF3B7C150A5Map());
            modelBuilder.Configurations.Add(new MSmerge_ctsv_8A4E7D7BDA80410696CD2E002F04C6A3Map());
            modelBuilder.Configurations.Add(new MSmerge_ctsv_8AD88F8E6A9843E0887D9D133B582E49Map());
            modelBuilder.Configurations.Add(new MSmerge_ctsv_912E10792A1642B594FBBA0BD6585863Map());
            modelBuilder.Configurations.Add(new MSmerge_ctsv_95BD04E007FC4F809C53B6B56F1FF5D0Map());
            modelBuilder.Configurations.Add(new MSmerge_ctsv_AF6A1B56B97547058295B125F28DED5EMap());
            modelBuilder.Configurations.Add(new MSmerge_ctsv_B14C2C3EF4AD4E729E88E0F5E862E96EMap());
            modelBuilder.Configurations.Add(new MSmerge_ctsv_B34D66C5A09648778BE2364D1B50ED14Map());
            modelBuilder.Configurations.Add(new MSmerge_ctsv_B93B4BF1EAA5447EB6A5F5B6827F41BFMap());
            modelBuilder.Configurations.Add(new MSmerge_ctsv_C469A03675D841B9B14DE6B6BC35DA77Map());
            modelBuilder.Configurations.Add(new MSmerge_ctsv_D858916FB3774522B844FBFD6C117C68Map());
            modelBuilder.Configurations.Add(new MSmerge_ctsv_DFAF17508C804EA186C353DE73055980Map());
            modelBuilder.Configurations.Add(new MSmerge_ctsv_E6E5B14B1F21410AB211FF7E4C85B272Map());
            modelBuilder.Configurations.Add(new MSmerge_ctsv_F9D70570176F45A79E27B75A427B83ABMap());
            modelBuilder.Configurations.Add(new MSmerge_FoxTick_Ads_VIEWMap());
            modelBuilder.Configurations.Add(new MSmerge_FoxTick_Alerts_VIEWMap());
            modelBuilder.Configurations.Add(new MSmerge_FoxTick_Banners_VIEWMap());
            modelBuilder.Configurations.Add(new MSmerge_FoxTick_ClientAlerts_VIEWMap());
            modelBuilder.Configurations.Add(new MSmerge_FoxTick_ClientGames_VIEWMap());
            modelBuilder.Configurations.Add(new MSmerge_FoxTick_ClientLogs_VIEWMap());
            modelBuilder.Configurations.Add(new MSmerge_FoxTick_ClientNetworks_VIEWMap());
            modelBuilder.Configurations.Add(new MSmerge_FoxTick_ClientNewsAlerts_VIEWMap());
            modelBuilder.Configurations.Add(new MSmerge_FoxTick_Clients_VIEWMap());
            modelBuilder.Configurations.Add(new MSmerge_FoxTick_ClientSports_VIEWMap());
            modelBuilder.Configurations.Add(new MSmerge_FoxTick_ClientStatuses_VIEWMap());
            modelBuilder.Configurations.Add(new MSmerge_FoxTick_ClientTeams_VIEWMap());
            modelBuilder.Configurations.Add(new MSmerge_FoxTick_EntryTypes_VIEWMap());
            modelBuilder.Configurations.Add(new MSmerge_FoxTick_GameNotes_VIEWMap());
            modelBuilder.Configurations.Add(new MSmerge_FoxTick_Games_VIEWMap());
            modelBuilder.Configurations.Add(new MSmerge_FoxTick_GameStats_VIEWMap());
            modelBuilder.Configurations.Add(new MSmerge_FoxTick_GameStatuses_VIEWMap());
            modelBuilder.Configurations.Add(new MSmerge_FoxTick_GroupAnimationTypes_VIEWMap());
            modelBuilder.Configurations.Add(new MSmerge_FoxTick_Groups_VIEWMap());
            modelBuilder.Configurations.Add(new MSmerge_FoxTick_ImporterLogs_VIEWMap());
            modelBuilder.Configurations.Add(new MSmerge_FoxTick_Importers_VIEWMap());
            modelBuilder.Configurations.Add(new MSmerge_FoxTick_ManagementGameNotes_VIEWMap());
            modelBuilder.Configurations.Add(new MSmerge_FoxTick_ManagementGames_VIEWMap());
            modelBuilder.Configurations.Add(new MSmerge_FoxTick_Networks_VIEWMap());
            modelBuilder.Configurations.Add(new MSmerge_FoxTick_NewsAlerts_VIEWMap());
            modelBuilder.Configurations.Add(new MSmerge_FoxTick_NFLGameNotes_VIEWMap());
            modelBuilder.Configurations.Add(new MSmerge_FoxTick_Notes_VIEWMap());
            modelBuilder.Configurations.Add(new MSmerge_FoxTick_Players_VIEWMap());
            modelBuilder.Configurations.Add(new MSmerge_FoxTick_PlaylistDetails_VIEWMap());
            modelBuilder.Configurations.Add(new MSmerge_FoxTick_Playlists_VIEWMap());
            modelBuilder.Configurations.Add(new MSmerge_FoxTick_Sports_VIEWMap());
            modelBuilder.Configurations.Add(new MSmerge_FoxTick_Statuses_VIEWMap());
            modelBuilder.Configurations.Add(new MSmerge_FoxTick_sysdiagrams_VIEWMap());
            modelBuilder.Configurations.Add(new MSmerge_FoxTick_Teams_VIEWMap());
            modelBuilder.Configurations.Add(new MSmerge_FoxTick_Users_VIEWMap());
            modelBuilder.Configurations.Add(new MSmerge_genvw_1BF552076F444AA98BA5A9B2B491BC60Map());
            modelBuilder.Configurations.Add(new MSmerge_genvw_20B74CEDDD5243D78EFB2AC883C0C742Map());
            modelBuilder.Configurations.Add(new MSmerge_genvw_33177264FB40407F8F7985E30690406FMap());
            modelBuilder.Configurations.Add(new MSmerge_genvw_3A27831AF4504C79AF0092DC4EAA0950Map());
            modelBuilder.Configurations.Add(new MSmerge_genvw_3B616ECE40DE406EA2F8C8EA0C730823Map());
            modelBuilder.Configurations.Add(new MSmerge_genvw_3F91A991094D4AA48825BE7ABD3BBC0DMap());
            modelBuilder.Configurations.Add(new MSmerge_genvw_465E8B89A97340D08709A08B7B71A00AMap());
            modelBuilder.Configurations.Add(new MSmerge_genvw_467DC94C223349C6A0417F1FD7AF9E7BMap());
            modelBuilder.Configurations.Add(new MSmerge_genvw_6652F91250544FAB9F2FFC8205704612Map());
            modelBuilder.Configurations.Add(new MSmerge_genvw_682A82085722461D932D23C14CC46688Map());
            modelBuilder.Configurations.Add(new MSmerge_genvw_6B580F3E807943A3BA6BB0531C7E4E43Map());
            modelBuilder.Configurations.Add(new MSmerge_genvw_6C8A90F5829646DB940996D053BBCE9BMap());
            modelBuilder.Configurations.Add(new MSmerge_genvw_6E6FC966139E429F86BA7566E3116F05Map());
            modelBuilder.Configurations.Add(new MSmerge_genvw_7036411C9AC14250956EEFB8CBB8E877Map());
            modelBuilder.Configurations.Add(new MSmerge_genvw_73502D14121E4B75A4C01D824B03C0D3Map());
            modelBuilder.Configurations.Add(new MSmerge_genvw_74067179DBA4420580563202F4C416A3Map());
            modelBuilder.Configurations.Add(new MSmerge_genvw_741B26DBF528453481B23E906DB4465DMap());
            modelBuilder.Configurations.Add(new MSmerge_genvw_7973FE55EF8F480EBF7BC482250D7A47Map());
            modelBuilder.Configurations.Add(new MSmerge_genvw_79B222F6368840A0BE11C3FD3C89ABB0Map());
            modelBuilder.Configurations.Add(new MSmerge_genvw_7EE304486F174938BDBAB19C2BE2D5A0Map());
            modelBuilder.Configurations.Add(new MSmerge_genvw_84B6FC92668D49B1A4C35D7543002859Map());
            modelBuilder.Configurations.Add(new MSmerge_genvw_8742FFF2F37E4D6795415DF3B7C150A5Map());
            modelBuilder.Configurations.Add(new MSmerge_genvw_8A4E7D7BDA80410696CD2E002F04C6A3Map());
            modelBuilder.Configurations.Add(new MSmerge_genvw_8AD88F8E6A9843E0887D9D133B582E49Map());
            modelBuilder.Configurations.Add(new MSmerge_genvw_912E10792A1642B594FBBA0BD6585863Map());
            modelBuilder.Configurations.Add(new MSmerge_genvw_95BD04E007FC4F809C53B6B56F1FF5D0Map());
            modelBuilder.Configurations.Add(new MSmerge_genvw_AF6A1B56B97547058295B125F28DED5EMap());
            modelBuilder.Configurations.Add(new MSmerge_genvw_B14C2C3EF4AD4E729E88E0F5E862E96EMap());
            modelBuilder.Configurations.Add(new MSmerge_genvw_B34D66C5A09648778BE2364D1B50ED14Map());
            modelBuilder.Configurations.Add(new MSmerge_genvw_B93B4BF1EAA5447EB6A5F5B6827F41BFMap());
            modelBuilder.Configurations.Add(new MSmerge_genvw_C469A03675D841B9B14DE6B6BC35DA77Map());
            modelBuilder.Configurations.Add(new MSmerge_genvw_D858916FB3774522B844FBFD6C117C68Map());
            modelBuilder.Configurations.Add(new MSmerge_genvw_DFAF17508C804EA186C353DE73055980Map());
            modelBuilder.Configurations.Add(new MSmerge_genvw_E6E5B14B1F21410AB211FF7E4C85B272Map());
            modelBuilder.Configurations.Add(new MSmerge_genvw_F9D70570176F45A79E27B75A427B83ABMap());
            modelBuilder.Configurations.Add(new MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_1BF552076F444AA98BA5A9B2B491BC60Map());
            modelBuilder.Configurations.Add(new MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_20B74CEDDD5243D78EFB2AC883C0C742Map());
            modelBuilder.Configurations.Add(new MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_33177264FB40407F8F7985E30690406FMap());
            modelBuilder.Configurations.Add(new MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_3A27831AF4504C79AF0092DC4EAA0950Map());
            modelBuilder.Configurations.Add(new MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_3B616ECE40DE406EA2F8C8EA0C730823Map());
            modelBuilder.Configurations.Add(new MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_3F91A991094D4AA48825BE7ABD3BBC0DMap());
            modelBuilder.Configurations.Add(new MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_465E8B89A97340D08709A08B7B71A00AMap());
            modelBuilder.Configurations.Add(new MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_467DC94C223349C6A0417F1FD7AF9E7BMap());
            modelBuilder.Configurations.Add(new MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_6652F91250544FAB9F2FFC8205704612Map());
            modelBuilder.Configurations.Add(new MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_682A82085722461D932D23C14CC46688Map());
            modelBuilder.Configurations.Add(new MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_6B580F3E807943A3BA6BB0531C7E4E43Map());
            modelBuilder.Configurations.Add(new MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_6C8A90F5829646DB940996D053BBCE9BMap());
            modelBuilder.Configurations.Add(new MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_6E6FC966139E429F86BA7566E3116F05Map());
            modelBuilder.Configurations.Add(new MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_7036411C9AC14250956EEFB8CBB8E877Map());
            modelBuilder.Configurations.Add(new MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_73502D14121E4B75A4C01D824B03C0D3Map());
            modelBuilder.Configurations.Add(new MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_74067179DBA4420580563202F4C416A3Map());
            modelBuilder.Configurations.Add(new MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_741B26DBF528453481B23E906DB4465DMap());
            modelBuilder.Configurations.Add(new MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_7973FE55EF8F480EBF7BC482250D7A47Map());
            modelBuilder.Configurations.Add(new MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_79B222F6368840A0BE11C3FD3C89ABB0Map());
            modelBuilder.Configurations.Add(new MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_7EE304486F174938BDBAB19C2BE2D5A0Map());
            modelBuilder.Configurations.Add(new MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_84B6FC92668D49B1A4C35D7543002859Map());
            modelBuilder.Configurations.Add(new MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_8742FFF2F37E4D6795415DF3B7C150A5Map());
            modelBuilder.Configurations.Add(new MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_8A4E7D7BDA80410696CD2E002F04C6A3Map());
            modelBuilder.Configurations.Add(new MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_8AD88F8E6A9843E0887D9D133B582E49Map());
            modelBuilder.Configurations.Add(new MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_912E10792A1642B594FBBA0BD6585863Map());
            modelBuilder.Configurations.Add(new MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_95BD04E007FC4F809C53B6B56F1FF5D0Map());
            modelBuilder.Configurations.Add(new MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_AF6A1B56B97547058295B125F28DED5EMap());
            modelBuilder.Configurations.Add(new MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_B14C2C3EF4AD4E729E88E0F5E862E96EMap());
            modelBuilder.Configurations.Add(new MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_B34D66C5A09648778BE2364D1B50ED14Map());
            modelBuilder.Configurations.Add(new MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_B93B4BF1EAA5447EB6A5F5B6827F41BFMap());
            modelBuilder.Configurations.Add(new MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_C469A03675D841B9B14DE6B6BC35DA77Map());
            modelBuilder.Configurations.Add(new MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_D858916FB3774522B844FBFD6C117C68Map());
            modelBuilder.Configurations.Add(new MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_DFAF17508C804EA186C353DE73055980Map());
            modelBuilder.Configurations.Add(new MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_E6E5B14B1F21410AB211FF7E4C85B272Map());
            modelBuilder.Configurations.Add(new MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_F9D70570176F45A79E27B75A427B83ABMap());
            modelBuilder.Configurations.Add(new MSmerge_tsvw_1BF552076F444AA98BA5A9B2B491BC60Map());
            modelBuilder.Configurations.Add(new MSmerge_tsvw_20B74CEDDD5243D78EFB2AC883C0C742Map());
            modelBuilder.Configurations.Add(new MSmerge_tsvw_33177264FB40407F8F7985E30690406FMap());
            modelBuilder.Configurations.Add(new MSmerge_tsvw_3A27831AF4504C79AF0092DC4EAA0950Map());
            modelBuilder.Configurations.Add(new MSmerge_tsvw_3B616ECE40DE406EA2F8C8EA0C730823Map());
            modelBuilder.Configurations.Add(new MSmerge_tsvw_3F91A991094D4AA48825BE7ABD3BBC0DMap());
            modelBuilder.Configurations.Add(new MSmerge_tsvw_465E8B89A97340D08709A08B7B71A00AMap());
            modelBuilder.Configurations.Add(new MSmerge_tsvw_467DC94C223349C6A0417F1FD7AF9E7BMap());
            modelBuilder.Configurations.Add(new MSmerge_tsvw_6652F91250544FAB9F2FFC8205704612Map());
            modelBuilder.Configurations.Add(new MSmerge_tsvw_682A82085722461D932D23C14CC46688Map());
            modelBuilder.Configurations.Add(new MSmerge_tsvw_6B580F3E807943A3BA6BB0531C7E4E43Map());
            modelBuilder.Configurations.Add(new MSmerge_tsvw_6C8A90F5829646DB940996D053BBCE9BMap());
            modelBuilder.Configurations.Add(new MSmerge_tsvw_6E6FC966139E429F86BA7566E3116F05Map());
            modelBuilder.Configurations.Add(new MSmerge_tsvw_7036411C9AC14250956EEFB8CBB8E877Map());
            modelBuilder.Configurations.Add(new MSmerge_tsvw_73502D14121E4B75A4C01D824B03C0D3Map());
            modelBuilder.Configurations.Add(new MSmerge_tsvw_74067179DBA4420580563202F4C416A3Map());
            modelBuilder.Configurations.Add(new MSmerge_tsvw_741B26DBF528453481B23E906DB4465DMap());
            modelBuilder.Configurations.Add(new MSmerge_tsvw_7973FE55EF8F480EBF7BC482250D7A47Map());
            modelBuilder.Configurations.Add(new MSmerge_tsvw_79B222F6368840A0BE11C3FD3C89ABB0Map());
            modelBuilder.Configurations.Add(new MSmerge_tsvw_7EE304486F174938BDBAB19C2BE2D5A0Map());
            modelBuilder.Configurations.Add(new MSmerge_tsvw_84B6FC92668D49B1A4C35D7543002859Map());
            modelBuilder.Configurations.Add(new MSmerge_tsvw_8742FFF2F37E4D6795415DF3B7C150A5Map());
            modelBuilder.Configurations.Add(new MSmerge_tsvw_8A4E7D7BDA80410696CD2E002F04C6A3Map());
            modelBuilder.Configurations.Add(new MSmerge_tsvw_8AD88F8E6A9843E0887D9D133B582E49Map());
            modelBuilder.Configurations.Add(new MSmerge_tsvw_912E10792A1642B594FBBA0BD6585863Map());
            modelBuilder.Configurations.Add(new MSmerge_tsvw_95BD04E007FC4F809C53B6B56F1FF5D0Map());
            modelBuilder.Configurations.Add(new MSmerge_tsvw_AF6A1B56B97547058295B125F28DED5EMap());
            modelBuilder.Configurations.Add(new MSmerge_tsvw_B14C2C3EF4AD4E729E88E0F5E862E96EMap());
            modelBuilder.Configurations.Add(new MSmerge_tsvw_B34D66C5A09648778BE2364D1B50ED14Map());
            modelBuilder.Configurations.Add(new MSmerge_tsvw_B93B4BF1EAA5447EB6A5F5B6827F41BFMap());
            modelBuilder.Configurations.Add(new MSmerge_tsvw_C469A03675D841B9B14DE6B6BC35DA77Map());
            modelBuilder.Configurations.Add(new MSmerge_tsvw_D858916FB3774522B844FBFD6C117C68Map());
            modelBuilder.Configurations.Add(new MSmerge_tsvw_DFAF17508C804EA186C353DE73055980Map());
            modelBuilder.Configurations.Add(new MSmerge_tsvw_E6E5B14B1F21410AB211FF7E4C85B272Map());
            modelBuilder.Configurations.Add(new MSmerge_tsvw_F9D70570176F45A79E27B75A427B83ABMap());
            modelBuilder.Configurations.Add(new sysmergeextendedarticlesviewMap());
            modelBuilder.Configurations.Add(new sysmergepartitioninfoviewMap());
            modelBuilder.Configurations.Add(new vwGamesCFBMap());
            modelBuilder.Configurations.Add(new vwNCAA_TeamTranslateMap());
            modelBuilder.Configurations.Add(new vwOnAirNamesFSPMap());
            modelBuilder.Configurations.Add(new vwTEMP_SoccerLeadersMap());
        }
    }
}
