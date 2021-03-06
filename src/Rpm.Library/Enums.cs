﻿namespace PackageManagement.Rpm.Library
{
    public enum PackageType
    {
        Binary = 0,
        Source = 1,
    }

    public enum TagType
    {
        Null = 0,
        Char = 1,
        Int8 = 2,
        Int16 = 3,
        Int32 = 4,
        Int64 = 5,
        String = 6,
        Bin = 7,
        StringArray = 8,
        I18NString = 9,
    }

    public enum SignatureTag
    {
        SIZE = 1000,  /*!< internal Header+Payload size (32bit) in bytes. */
        LEMD5_1 = 1001,   /*!< internal Broken MD5, take 1 @deprecated legacy. */
        PGP = 1002,   /*!< internal PGP 2.6.3 signature. */
        LEMD5_2 = 1003,   /*!< internal Broken MD5, take 2 @deprecated legacy. */
        MD5 = 1004,   /*!< internal MD5 signature. */
        GPG = 1005, /*!< internal GnuPG signature. */
        PGP5 = 1006,  /*!< internal PGP5 signature @deprecated legacy. */
        PAYLOADSIZE = 1007,/*!< internal uncompressed payload size (32bit) in bytes. */
        RESERVEDSPACE = 1008,/*!< internal space reserved for signatures */
        BADSHA1_1 = Tag.BADSHA1_1, /*!< internal Broken SHA1, take 1. */
        BADSHA1_2 = Tag.BADSHA1_2, /*!< internal Broken SHA1, take 2. */
        DSA = Tag.DSAHEADER,   /*!< internal DSA header signature. */
        RSA = Tag.RSAHEADER,   /*!< internal RSA header signature. */
        SHA1 = Tag.SHA1HEADER, /*!< internal sha1 header digest. */
        LONGSIZE = Tag.LONGSIGSIZE,    /*!< internal Header+Payload size (64bit) in bytes. */
        LONGARCHIVESIZE = Tag.LONGARCHIVESIZE, /*!< internal uncompressed payload size (64bit) in bytes. */
        SHA256 = Tag.SHA256HEADER,
        FILESIGNATURES = Tag.SIG_BASE + 18,
        FILESIGNATURELENGTH = Tag.SIG_BASE + 19,
    }

    // Tags identify data in package headers.
    // @note tags should not have value 0!
    public enum Tag
    {
        NOT_FOUND = -1,          /*!< Unknown tag */

        HEADERIMAGE = 61,      /*!< Current image. */
        HEADERSIGNATURES = 62,    /*!< Signatures. */
        HEADERIMMUTABLE = 63,  /*!< Original image. */
        HEADERREGIONS = 64,  /*!< Regions. */

        HEADERI18NTABLE = 100,  /* s[] !< I18N string locales. */

        /* Retrofit (and uniqify) signature tags for use by rpmTagGetName() and rpmQuery. */
        /* the md5 sum was broken *twice* on big endian machines */
        /* XXX 2nd underscore prevents tagTable generation */
        SIG_BASE = 256,
        SIGSIZE = SIG_BASE + 1,   /* i */
        SIGLEMD5_1 = SIG_BASE + 2,    /* internal - obsolete */
        SIGPGP = SIG_BASE + 3,    /* x */
        SIGLEMD5_2 = SIG_BASE + 4,    /* x internal - obsolete */
        SIGMD5 = SIG_BASE + 5,    /* x */
        SIGGPG = SIG_BASE + 6,    /* x */
        SIGPGP5 = SIG_BASE + 7,   /* internal - obsolete */

        BADSHA1_1 = SIG_BASE + 8, /* internal - obsolete */
        BADSHA1_2 = SIG_BASE + 9, /* internal - obsolete */
        PUBKEYS = SIG_BASE + 10,  /* s[] */
        DSAHEADER = SIG_BASE + 11,    /* x */
        RSAHEADER = SIG_BASE + 12,    /* x */
        SHA1HEADER = SIG_BASE + 13,   /* s */
        LONGSIGSIZE = SIG_BASE + 14,  /* l */
        LONGARCHIVESIZE = SIG_BASE + 15,  /* l */
                                                        /* SIG_BASE+16 reserved */
        SHA256HEADER = SIG_BASE + 17, /* s */
                                                    /* SIG_BASE+18 reserved for RPMSIGTAG_FILESIGNATURES */
                                                    /* SIG_BASE+19 reserved for RPMSIGTAG_FILESIGNATURELENGTH */

        NAME = 1000, /* s */
        VERSION = 1001,  /* s */
        RELEASE = 1002,  /* s */
        EPOCH = 1003,    /* i */
        SUMMARY = 1004,  /* s{} */
        DESCRIPTION = 1005,  /* s{} */
        BUILDTIME = 1006,    /* i */
        BUILDHOST = 1007,    /* s */
        INSTALLTIME = 1008,  /* i */
        SIZE = 1009, /* i */
        DISTRIBUTION = 1010, /* s */
        VENDOR = 1011,   /* s */
        GIF = 1012,  /* x */
        XPM = 1013,  /* x */
        LICENSE = 1014,  /* s */
        PACKAGER = 1015, /* s */
        GROUP = 1016,    /* s{} */
        CHANGELOG = 1017, /* s[] internal */
        SOURCE = 1018,   /* s[] */
        PATCH = 1019,    /* s[] */
        URL = 1020,  /* s */
        OS = 1021,   /* s legacy used int */
        ARCH = 1022, /* s legacy used int */
        PREIN = 1023,    /* s */
        POSTIN = 1024,   /* s */
        PREUN = 1025,    /* s */
        POSTUN = 1026,   /* s */
        OLDFILENAMES = 1027, /* s[] obsolete */
        FILESIZES = 1028,    /* i[] */
        FILESTATES = 1029, /* c[] */
        FILEMODES = 1030,    /* h[] */
        FILEUIDS = 1031, /* i[] internal - obsolete */
        FILEGIDS = 1032, /* i[] internal - obsolete */
        FILERDEVS = 1033,    /* h[] */
        FILEMTIMES = 1034, /* i[] */
        FILEDIGESTS = 1035,  /* s[] */
        FILELINKTOS = 1036,  /* s[] */
        FILEFLAGS = 1037,    /* i[] */
        ROOT = 1038, /* internal - obsolete */
        FILEUSERNAME = 1039, /* s[] */
        FILEGROUPNAME = 1040,    /* s[] */
        EXCLUDE = 1041, /* internal - obsolete */
        EXCLUSIVE = 1042, /* internal - obsolete */
        ICON = 1043, /* x */
        SOURCERPM = 1044,    /* s */
        FILEVERIFYFLAGS = 1045,  /* i[] */
        ARCHIVESIZE = 1046,  /* i */
        PROVIDENAME = 1047,  /* s[] */
        REQUIREFLAGS = 1048, /* i[] */
        REQUIRENAME = 1049,  /* s[] */
        REQUIREVERSION = 1050,   /* s[] */
        NOSOURCE = 1051, /* i[] */
        NOPATCH = 1052, /* i[] */
        CONFLICTFLAGS = 1053, /* i[] */
        CONFLICTNAME = 1054, /* s[] */
        CONFLICTVERSION = 1055,  /* s[] */
        DEFAULTPREFIX = 1056, /* s internal - deprecated */
        BUILDROOT = 1057, /* s internal - obsolete */
        INSTALLPREFIX = 1058, /* s internal - deprecated */
        EXCLUDEARCH = 1059, /* s[] */
        EXCLUDEOS = 1060, /* s[] */
        EXCLUSIVEARCH = 1061, /* s[] */
        EXCLUSIVEOS = 1062, /* s[] */
        AUTOREQPROV = 1063, /* s internal */
        RPMVERSION = 1064,   /* s */
        TRIGGERSCRIPTS = 1065,   /* s[] */
        TRIGGERNAME = 1066,  /* s[] */
        TRIGGERVERSION = 1067,   /* s[] */
        TRIGGERFLAGS = 1068, /* i[] */
        TRIGGERINDEX = 1069, /* i[] */
        VERIFYSCRIPT = 1079, /* s */
        CHANGELOGTIME = 1080,    /* i[] */
        CHANGELOGNAME = 1081,    /* s[] */
        CHANGELOGTEXT = 1082,    /* s[] */
        BROKENMD5 = 1083, /* internal - obsolete */
        PREREQ = 1084, /* internal */
        PREINPROG = 1085,    /* s[] */
        POSTINPROG = 1086,   /* s[] */
        PREUNPROG = 1087,    /* s[] */
        POSTUNPROG = 1088,   /* s[] */
        BUILDARCHS = 1089, /* s[] */
        OBSOLETENAME = 1090, /* s[] */
        VERIFYSCRIPTPROG = 1091, /* s[] */
        TRIGGERSCRIPTPROG = 1092,    /* s[] */
        DOCDIR = 1093, /* internal */
        COOKIE = 1094,   /* s */
        FILEDEVICES = 1095,  /* i[] */
        FILEINODES = 1096,   /* i[] */
        FILELANGS = 1097,    /* s[] */
        PREFIXES = 1098, /* s[] */
        INSTPREFIXES = 1099, /* s[] */
        TRIGGERIN = 1100, /* internal */
        TRIGGERUN = 1101, /* internal */
        TRIGGERPOSTUN = 1102, /* internal */
        AUTOREQ = 1103, /* internal */
        AUTOPROV = 1104, /* internal */
        CAPABILITY = 1105, /* i internal - obsolete */
        SOURCEPACKAGE = 1106, /* i */
        OLDORIGFILENAMES = 1107, /* internal - obsolete */
        BUILDPREREQ = 1108, /* internal */
        BUILDREQUIRES = 1109, /* internal */
        BUILDCONFLICTS = 1110, /* internal */
        BUILDMACROS = 1111, /* internal - unused */
        PROVIDEFLAGS = 1112, /* i[] */
        PROVIDEVERSION = 1113,   /* s[] */
        OBSOLETEFLAGS = 1114,    /* i[] */
        OBSOLETEVERSION = 1115,  /* s[] */
        DIRINDEXES = 1116,   /* i[] */
        BASENAMES = 1117,    /* s[] */
        DIRNAMES = 1118, /* s[] */
        ORIGDIRINDEXES = 1119, /* i[] relocation */
        ORIGBASENAMES = 1120, /* s[] relocation */
        ORIGDIRNAMES = 1121, /* s[] relocation */
        OPTFLAGS = 1122, /* s */
        DISTURL = 1123,  /* s */
        PAYLOADFORMAT = 1124,    /* s */
        PAYLOADCOMPRESSOR = 1125,    /* s */
        PAYLOADFLAGS = 1126, /* s */
        INSTALLCOLOR = 1127, /* i transaction color when installed */
        INSTALLTID = 1128,   /* i */
        REMOVETID = 1129,    /* i */
        SHA1RHN = 1130, /* internal - obsolete */
        RHNPLATFORM = 1131,  /* s internal - obsolete */
        PLATFORM = 1132, /* s */
        PATCHESNAME = 1133, /* s[] deprecated placeholder (SuSE) */
        PATCHESFLAGS = 1134, /* i[] deprecated placeholder (SuSE) */
        PATCHESVERSION = 1135, /* s[] deprecated placeholder (SuSE) */
        CACHECTIME = 1136,   /* i internal - obsolete */
        CACHEPKGPATH = 1137, /* s internal - obsolete */
        CACHEPKGSIZE = 1138, /* i internal - obsolete */
        CACHEPKGMTIME = 1139,    /* i internal - obsolete */
        FILECOLORS = 1140,   /* i[] */
        FILECLASS = 1141,    /* i[] */
        CLASSDICT = 1142,    /* s[] */
        FILEDEPENDSX = 1143, /* i[] */
        FILEDEPENDSN = 1144, /* i[] */
        DEPENDSDICT = 1145,  /* i[] */
        SOURCEPKGID = 1146,  /* x */
        FILECONTEXTS = 1147, /* s[] - obsolete */
        FSCONTEXTS = 1148,   /* s[] extension */
        RECONTEXTS = 1149,   /* s[] extension */
        POLICIES = 1150, /* s[] selinux *.te policy file. */
        PRETRANS = 1151, /* s */
        POSTTRANS = 1152,    /* s */
        PRETRANSPROG = 1153, /* s[] */
        POSTTRANSPROG = 1154,    /* s[] */
        DISTTAG = 1155,  /* s */
        OLDSUGGESTSNAME = 1156, /* s[] - obsolete */
        OLDSUGGESTSVERSION = 1157,   /* s[] - obsolete */
        OLDSUGGESTSFLAGS = 1158, /* i[] - obsolete */
        OLDENHANCESNAME = 1159,  /* s[] - obsolete */
        OLDENHANCESVERSION = 1160,   /* s[] - obsolete */
        OLDENHANCESFLAGS = 1161, /* i[] - obsolete */
        PRIORITY = 1162, /* i[] extension placeholder (unimplemented) */
        CVSID = 1163, /* s (unimplemented) */
        BLINKPKGID = 1164, /* s[] (unimplemented) */
        BLINKHDRID = 1165, /* s[] (unimplemented) */
        BLINKNEVRA = 1166, /* s[] (unimplemented) */
        FLINKPKGID = 1167, /* s[] (unimplemented) */
        FLINKHDRID = 1168, /* s[] (unimplemented) */
        FLINKNEVRA = 1169, /* s[] (unimplemented) */
        PACKAGEORIGIN = 1170, /* s (unimplemented) */
        TRIGGERPREIN = 1171, /* internal */
        BUILDSUGGESTS = 1172, /* internal (unimplemented) */
        BUILDENHANCES = 1173, /* internal (unimplemented) */
        SCRIPTSTATES = 1174, /* i[] scriptlet exit codes (unimplemented) */
        SCRIPTMETRICS = 1175, /* i[] scriptlet execution times (unimplemented) */
        BUILDCPUCLOCK = 1176, /* i (unimplemented) */
        FILEDIGESTALGOS = 1177, /* i[] (unimplemented) */
        VARIANTS = 1178, /* s[] (unimplemented) */
        XMAJOR = 1179, /* i (unimplemented) */
        XMINOR = 1180, /* i (unimplemented) */
        REPOTAG = 1181,  /* s (unimplemented) */
        KEYWORDS = 1182, /* s[] (unimplemented) */
        BUILDPLATFORMS = 1183,   /* s[] (unimplemented) */
        PACKAGECOLOR = 1184, /* i (unimplemented) */
        PACKAGEPREFCOLOR = 1185, /* i (unimplemented) */
        XATTRSDICT = 1186, /* s[] (unimplemented) */
        FILEXATTRSX = 1187, /* i[] (unimplemented) */
        DEPATTRSDICT = 1188, /* s[] (unimplemented) */
        CONFLICTATTRSX = 1189, /* i[] (unimplemented) */
        OBSOLETEATTRSX = 1190, /* i[] (unimplemented) */
        PROVIDEATTRSX = 1191, /* i[] (unimplemented) */
        REQUIREATTRSX = 1192, /* i[] (unimplemented) */
        BUILDPROVIDES = 1193, /* internal (unimplemented) */
        BUILDOBSOLETES = 1194, /* internal (unimplemented) */
        DBINSTANCE = 1195, /* i extension */
        NVRA = 1196, /* s extension */

        /* tags 1997-4999 reserved */
        FILENAMES = 5000, /* s[] extension */
        FILEPROVIDE = 5001, /* s[] extension */
        FILEREQUIRE = 5002, /* s[] extension */
        FSNAMES = 5003, /* s[] (unimplemented) */
        FSSIZES = 5004, /* l[] (unimplemented) */
        TRIGGERCONDS = 5005, /* s[] extension */
        TRIGGERTYPE = 5006, /* s[] extension */
        ORIGFILENAMES = 5007, /* s[] extension */
        LONGFILESIZES = 5008,    /* l[] */
        LONGSIZE = 5009, /* l */
        FILECAPS = 5010, /* s[] */
        FILEDIGESTALGO = 5011, /* i file digest algorithm */
        BUGURL = 5012, /* s */
        EVR = 5013, /* s extension */
        NVR = 5014, /* s extension */
        NEVR = 5015, /* s extension */
        NEVRA = 5016, /* s extension */
        HEADERCOLOR = 5017, /* i extension */
        VERBOSE = 5018, /* i extension */
        EPOCHNUM = 5019, /* i extension */
        PREINFLAGS = 5020, /* i */
        POSTINFLAGS = 5021, /* i */
        PREUNFLAGS = 5022, /* i */
        POSTUNFLAGS = 5023, /* i */
        PRETRANSFLAGS = 5024, /* i */
        POSTTRANSFLAGS = 5025, /* i */
        VERIFYSCRIPTFLAGS = 5026, /* i */
        TRIGGERSCRIPTFLAGS = 5027, /* i[] */
        COLLECTIONS = 5029, /* s[] list of collections (unimplemented) */
        POLICYNAMES = 5030,  /* s[] */
        POLICYTYPES = 5031,  /* s[] */
        POLICYTYPESINDEXES = 5032,   /* i[] */
        POLICYFLAGS = 5033,  /* i[] */
        VCS = 5034, /* s */
        ORDERNAME = 5035,    /* s[] */
        ORDERVERSION = 5036, /* s[] */
        ORDERFLAGS = 5037,   /* i[] */
        MSSFMANIFEST = 5038, /* s[] reservation (unimplemented) */
        MSSFDOMAIN = 5039, /* s[] reservation (unimplemented) */
        INSTFILENAMES = 5040, /* s[] extension */
        REQUIRENEVRS = 5041, /* s[] extension */
        PROVIDENEVRS = 5042, /* s[] extension */
        OBSOLETENEVRS = 5043, /* s[] extension */
        CONFLICTNEVRS = 5044, /* s[] extension */
        FILENLINKS = 5045,   /* i[] extension */
        RECOMMENDNAME = 5046,    /* s[] */
        RECOMMENDVERSION = 5047, /* s[] */
        RECOMMENDFLAGS = 5048,   /* i[] */
        SUGGESTNAME = 5049,  /* s[] */
        SUGGESTVERSION = 5050,   /* s[] extension */
        SUGGESTFLAGS = 5051, /* i[] extension */
        SUPPLEMENTNAME = 5052,   /* s[] */
        SUPPLEMENTVERSION = 5053,    /* s[] */
        SUPPLEMENTFLAGS = 5054,  /* i[] */
        ENHANCENAME = 5055,  /* s[] */
        ENHANCEVERSION = 5056,   /* s[] */
        ENHANCEFLAGS = 5057, /* i[] */
        RECOMMENDNEVRS = 5058, /* s[] extension */
        SUGGESTNEVRS = 5059, /* s[] extension */
        SUPPLEMENTNEVRS = 5060, /* s[] extension */
        ENHANCENEVRS = 5061, /* s[] extension */
        ENCODING = 5062, /* s */
        FILETRIGGERIN = 5063, /* internal */
        FILETRIGGERUN = 5064, /* internal */
        FILETRIGGERPOSTUN = 5065, /* internal */
        FILETRIGGERSCRIPTS = 5066, /* s[] */
        FILETRIGGERSCRIPTPROG = 5067, /* s[] */
        FILETRIGGERSCRIPTFLAGS = 5068, /* i[] */
        FILETRIGGERNAME = 5069, /* s[] */
        FILETRIGGERINDEX = 5070, /* i[] */
        FILETRIGGERVERSION = 5071, /* s[] */
        FILETRIGGERFLAGS = 5072, /* i[] */
        TRANSFILETRIGGERIN = 5073, /* internal */
        TRANSFILETRIGGERUN = 5074, /* internal */
        TRANSFILETRIGGERPOSTUN = 5075, /* internal */
        TRANSFILETRIGGERSCRIPTS = 5076, /* s[] */
        TRANSFILETRIGGERSCRIPTPROG = 5077, /* s[] */
        TRANSFILETRIGGERSCRIPTFLAGS = 5078, /* i[] */
        TRANSFILETRIGGERNAME = 5079, /* s[] */
        TRANSFILETRIGGERINDEX = 5080, /* i[] */
        TRANSFILETRIGGERVERSION = 5081, /* s[] */
        TRANSFILETRIGGERFLAGS = 5082, /* i[] */
        REMOVEPATHPOSTFIXES = 5083, /* s internal */
        FILETRIGGERPRIORITIES = 5084, /* i[] */
        TRANSFILETRIGGERPRIORITIES = 5085, /* i[] */
        FILETRIGGERCONDS = 5086, /* s[] extension */
        FILETRIGGERTYPE = 5087, /* s[] extension */
        TRANSFILETRIGGERCONDS = 5088, /* s[] extension */
        TRANSFILETRIGGERTYPE = 5089, /* s[] extension */
        FILESIGNATURES = 5090, /* s[] */
        FILESIGNATURELENGTH = 5091, /* i */
        PAYLOADDIGEST = 5092, /* s[] */
        PAYLOADDIGESTALGO = 5093, /* i */

        FIRSTFREE_TAG    /*!< internal */
    }
}
