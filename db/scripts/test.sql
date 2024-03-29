﻿# SQL Test file

call GetCategories();
call InsertCategory('x');
call InsertCategory('abcdefgh...');
call DeleteCategory('abcdefgh...');
call UpdateCategory('x','xyz');

call InsertLanguage('bbbbb');
call InsertLanguage('ddddd');
call DeleteLanguage('bbbbb');
call DeleteLanguage('ddddd');

call GetLanguages();
call InsertLanguage('a');
call DeleteLanguage('a');
call DeleteLanguage('b');
call InsertLanguage('c');
call UpdateLanguage('c','ccc');

# Concurrency test on InsertCategory stored procedure: 50 random test cases
call InsertCategory('5DMJ4R8NXSMWXYILC32BSCA4YGDBXFP38O92RX379VNFHTW4T2GYEUEJTN2W72O6UUYMOOHP4U6GTQ0LB75B0MJVD7J6U4C09UOBSAB0EWWTD1YVS3O4HNVMRUMQNFVUDHAK3SZ4ZXFZN044Y5C796IULR52RZ8R36KTBZY2EO419P1D8BEEJUPDCO7VQ9O03DMQET7WY938XR2VVVEKCJS8RFY4FRMQ8C8DS649WH0XS0PLKWPGNZU4ENBBOEZ');
call InsertCategory('L4IN72E5B1HBHNBJNLA3ZMCUP1AD55CHZJ12ULXDIVNYKHJNSV40QG8BGOR1FKIZJE5YMIQRC9OJIGXLN4YEKQL69MFDM0KLBNTTIEGL04LB2AMMGH2AQSC2WWB3IQNE7CYGQ7MY3R8DXJQN0QCZA2LS5CHQRVWIDBUPBODK2F49DEI3VA11B0ZB9XMI641ZUS2W6JRKUO83YA2VQ20PR6FCUM6WELJYUV7A4GW9R53XE8XPQF5OMNYILOP4LVV');
call InsertCategory('FO4FHRXEM39Z9NFPO5MZQ8DMPIQKR88VVH1EUAGJX11HGZZ9S0RQUE34U1FMSUR47EO0IPSV72CTIMC2H3ZGFPWM3SBMZHVLGUZG9CI7HIPI8FLOCF3K76AO6O1B66DMNCX3IL7B2ZYMISN1CZ9MHERHB1VXCN5ZA16MVS1VDJVU58RSNYIUJCGD4OMVO6RPXF8SX981GKG3GHJMIGBB9RLTJQJFHZRPZUY1TBF25HK6DGWWUQ09H0A0EBYLWTE');
call InsertCategory('N5MKZQQ4K3289MIQTQAXBC0IK47JWX5A987BL5HHW5WGAY6UN2E4FX4EQSPCPTYBNREC4MGFER6HRKY60JBVBEIOL6YOV8XPCSPCSB35FR8JPK1WJ1RB6AXAV6I0HKKD0K0FJ3HBXE9N2VF6PVL1B1HHXYOP3KV8IO9ORROZVSBZSI5SNMJXW4QF35N7RG1D8CWPOTSSCGMD8RQ7A4APVSY1JIA60YBTH55A3QXJGZQN3CYWPNSGT9Y195AZLW9');
call InsertCategory('H9OYBMDRNCTTO4WWVV4T91QIA2DHBM30FXXJWR4JJ5QUCIMQ8P3M4E3TP4ST8QD3CMDV9BLK7GQRERZYGTG1ED3HNKJ4PTW37FXZDESUQXM0J9YYKDC974AI0XG5X5B0WPF3GU141P0Y23A6TVQGFMNLTI0CQ901ITRWV3EJNE7MLI48OEMLODE5GNFOMEEDU53QCTHXBSJIAO586TE35QUN6FYJ3J9H2PVBM25RA7PEMWXKY0PCDE9AT1616VG');
call InsertCategory('NQBX04XE1KAEXWUXQAF3CSZ40UO3XQWCU4KNZYKEIKZKDTPOIY5040G7H9PJV0XF30IWK5NLS40U18K8PGQGLNHUOFQXPAJ1BTY9Q6B0INKOPI1ALKSP5ZDN396I0JFVTXDLOPPXZDE1G2ZEGZV4GNJI5DA7DQAH2K0URQW5864TYPJHGP048OTR39WPM1WSKDH6MLUCE06OSFU0MM7FADIBTY7M80MCAQKO4NE76UCLF0TBBV4UCFJKGAXSND7');
call InsertCategory('EPSDTK94KKUCEI8VYNV69AP8P2Y4U8CSSH180BFS32S1F0LFJIA9PBBNBZUWZTRK6KH8VFJOX3HD6GBRGX0EJCYF7L3WCV2AK9JTNBIM74TJI00UJ0P9M4VGSBD122N9ZMXS0VLW7H1H5S72UR1285GC6BC5GOL39VHH2692JA745P5ZDJFZ0LONEUW1401G54AMGY14DVKKKI748TBWANPQI9JOUM4BCSE6ZRBXUKW674QNZZYTKIVA5YRCEB7');
call InsertCategory('VKCVX0PQ3WGB2IIQ5JI2SXY4ZQHUZ2M1AHT5IE2A324LBNBB3KH94SVAH2P5JOQYUS4RFXU1JO6SG2FT7JYQSXF3F8E6GH2T1PE4D1CDRCG7ZTFJ1I8HTJ7BC2G1ZJZQXPC299DAFA3F22K22RR0H84E1I580LLP34IIBK03MOXN2ZCLP85Q152518QTKDTXYDC9MNVERBXV9BT4S1CGCYRXUW27S6IN8J4SQU1R5P1XQAIVBUHWQP2YM75DWKI');
call InsertCategory('B9R2BKFH4E05J9Q2J4J61O8BW5RCIHN5WZT96GSM89MOT33SN00JOBRHC7G57N00IP4UJJMJYH4HEW3XLYW7OI49NBJ62FVFLBEFB9MO88V2TMQUIOSKVZGVXZHV0J46BT42R4AXDUK6SNLTG7UKAC1TOKT2GFPK1WESLAKOQSQPAQ5L5ETGDK2VKBK6Z6MGDG2AE1XP6QP70SHDCV80DAM445N9AT309K2EKQTLMJVSJTQZ02MP4099S3XQ035');
call InsertCategory('HD9MY20GA352XL3EVIY9BHIKHKIFMQAZU4W42ZE0KYGG5YBKH7VN4Q88NSYAAXZ78FJYJA23WHS36SFC3KVN8K1ZR7PR6ZZ2UELEHNZRHLW1NEATFPQ5LAI0PVF8GM6ZTECQY7XC2TPAEKIC5KYC91MLFOFIOOETY455UGJBSXRUYIESHTX1HAA9WC0HDU7U022NHNINZWJQ7T2FG4NPTP1W3BFFLZO8WUZW9S5LD99MSWWF4U9LKOARMP716WY');
call InsertCategory('Z2U0HGJZU8M3KXVISN58RBVFB4EWCAK3GOK92UJJZ3G01Y1DQP8FDZ8O9NGGC8KU1IWDOWXH2E72GDOYHPRHQROBSQIEESIPZ0JEUP2GXAP4XDNKYJRJVLEHE8ULRWTTZ0X21VT5SBPN5H23V42LFBQXNG4BHMQA8LE1A8B6EY57KTAUXLYO16OLXMY35EZPKKO3GGWW1TEGVNNRD4NYLX15CSFKRPHDV3REFKORBZ6ST04NZQY1675H0AZYEH6');
call InsertCategory('WFM4EIFP5GLX8KO80HC52K5RMKIQMN202F1PDL74DIMMR0COPJ5KTE3QKKPI3KBTPTKPQECDBNK8AQRT73R5PH2DWQILFOP4KJBN3ICI4TOO3ZR7NTSON6RTQHHYIEZCC85L0XXVQCHR708KTGSBFLG3E2CQPK5ADWC47O9QEW7C0WBC3KA85ARWYOB52KOV32VOBSNHY8U4MINJ31AYJ30ZDYO0DS4GY0C3VHT639A2JCB3CTSOV82ET67WA7G');
call InsertCategory('68RZFWBB8X4RKSQIC1L4GP3N5F986OKQUCR7HGMUGF4NQ3H2HWK0862ZNJ3F6CYICT6O2NXIV56M5TB5886KXFC6LKDF7QACSUH9CY3SFR7H1IHUY9DQIXF6QA08ODNRW1SHR1H1JT4593PUYS7AIJARGYH675RZ0MA71HZOC6GV8VC52U8NHTVCBMI11QWKDF9RBD29XVYOSMCN0WQALY98JEVS4LXEYLPJF2A8QP21Z4Y0NEZ1QNTLEGEFQ87');
call InsertCategory('EDVNBV7LLUIBD34KQG43RTX8HD8DWWOY8AC2O969EK4XSE8XWC1BI6F6EDYK2GBMXT4PX61H3P186I30TMVFVPG6L6Z4O6RAS2T4WS060GAG552Y4NV1E407R48BHBA2CEPD7C222JR3TCR53HX2H7UTZA6Y2TUBXVHEZMJZSQB3QP9H4QJYKJKPCCSFE84SZ83HOD56FHJO67EGN4VW6Q6NNPWK8BNHIFP7X8RWCEFF8SDCF4KI2BTJY3R7YSU');
call InsertCategory('6KP4Q2HL9HFTCFE48YLOHPYCYXBI8IL8NDSP86GG7FKPUB85KS79UG8G0PGLE2JUUSNE0XK6RAN2JTHURA25OLLLQU4VWPY93UJEH1R64N5847IC6SBC42UHYRRX4J0Q1IX4RZPXZ0JTDB4NDJPGP8B7YMMV8FI80PQBHNTM3GJ26VI0UOPCHHTL8TE7C0SYV0UK8QRHG82UO9ORMTLHEZOMZ9ODLMKPXPV8UB5TTM03AFR2INBF7GDK6RX96FQ');
call InsertCategory('9MMM3K33Q9XTFOMMMECPSDVQAKBE41RUHJGGJ1ZT2UW5WU1PW1ULJGFQOCSCBGEGE1G1RAA5V3OHJCN7K69J6LQKSBWCPCC4A46GKV5R4YZ4AT99QCYP7B1XQX7ZFPB7OHI7LTE38C16DHOLGJEGCGFJFGMOX3QMIRL2UGS8MK7EGONGDH0C5TC6B1AKNFAMF8A58DK02AALF8178BTTMWESNQ8TM8FMIYDCT5QB8UTH0MIZKLCRCOXUKW4B6XW');
call InsertCategory('NJN7X25QXCDZ3AW79N4VLPKBB8662URMBLGHXLLKYCUVLB4OLXG5NRLTIOS3M7928IVIMATHA5HM68YPW3ZT72DZ10G3VIVSK41C629UA2JAHLR9HIBEO3WS905D6IZXEF0HMDIC4RCCQ0XDL1S1K7Z60QN37PQRE3XKQU6YPAQKPRFUEKCJM51TVCY59PHC8079KSFPXYET77QPL0OXIB711K99K9Y2N5FF6J019HWH8TBB01NF3MR3RXVKSJ6');
call InsertCategory('I12BR48TPPSLF2JM4RCK2PK206670OEJ7N0ST309T26DTW155404LEJMXZ26ROMBT115TO95MFJQNTOE1L23GP94T6Z3YTPUXL38PW8UE10BPCWPFJVBO8YHGD433OMWKLJXIX0C1IQXW6KS1KG406H7MQG2MMNIKAQLG18J7FFB6UY80HEGTPXQ66FM8L2D533LLIWOSHX3LZ34Z2KPNCGIVOJ9PYNLKBVTYNQS4EZVIDYUORP62N5UTTVIAJ6');
call InsertCategory('R54ACSZARBR8UI6HNHIRSU753XFYVI417LATB6UY5N1BRDBCG47MNXXNDJX8NOQL0916GJ81LJ3EVEXF1475SICRLO295JGDDIKWQXYBSKUMZSZQOM3VOGHW2YFGHSKQXZQFXA92CZSUG1TNP87BRD1EHGIJTJXIYZKR60AZKC0IP6C22FZ1453LCFVXSDVZFLORVMEW2U7RNNS94WRRFEQ2WVT1NX1NTZXIGFGRW86CLVJF1Z9Z272W9GZL6XJ');
call InsertCategory('I24FLSLDKKBNPJ3JQ2VGU17114K5UCP2VGNK6XDYJT4J20NJ6CL22FFCP1MA5W6AUXFCN233SV9CUHHAEAAR6JZ55QD1M7YTTCLX1LKKLN468K3A86Z980PF6J0LNYBJJ917ESWY0U4WD63RLR75ECYHW49DUWRRZ9CKN6CAZW4OBT9DFJ972K1VPMKFEVS883KTPD617VL8BR0MMA8JD099JFD03HNQBDLR9GWSDVFL24C8ZFLFGR0ILH3140L');
call InsertCategory('N7D5WJNVANQBTFD97P7VVAAZC5WO6XHZKWUHFDKZIZKI0AWEYIRGUSW67F91PZOBXD43GQIIF0BMOR2SUIUYFPY0ENP9DECDLAMD0HEA61I3GB8V1QYIQDZXUTMF5Z9XGOGVYYCEKHNE6FR7SWS3UI4OW04JJ9FYP2YD1W22I4ABB5W1YOKVB05O1CX8HRXLHQS5WZ3653Z4S7ZHNP0YPB888HOI9YXVLGUS17IR29OLVNXHGE6LIV6WLCA4PZX');
call InsertCategory('7V1L12JEJ71U0MD5XIK8N0NXTLLCUNBT4JERTOXZAD378VVL9OCRMIPHIV3469F4C6FNTFKKE8XDN5JA7FF26EPQQCR63ENX0QC92KN4QPWNG5GIE4PYDORPFGHR6MCY731XNC0V6Q4ZME5K2MWEEXBECAAG1C7VNWCVIUYRIAP26DO5P5XFNURGLAR7A7W9SEKNTQSL25KP7IAILMZ9V97LTZJI10HXXR9B8R7T44TC8CM6RHET97AY5WTMRA6');
call InsertCategory('DV8YEPSM08EMQS18K3AIXXAV9O85040JEGJ8FVU44TVQMTPWFXFFQT57I6SB0J7Z3Z8FL8G8N3N5H2G1MFT8NIVX6SPNDYOBRLNVM5P1NHGH3KKBMTDBJZ2W4B0NYS3CICNG7EPBJT9YNWOZ1DYP7CD3J4KFNPHHNP864AG6GRHU6WLCNVF02RU7P3SBA3RJ4692HTTV04181MCBQSPSP45MCD1YJ9CEJI9YL5DJ1ZX3D7X6LF6X8ME25OG5UV2');
call InsertCategory('MSHHT9GD378FV4TZJ0UUM2ODPVMUIH5AC0TJDKDITLLK25J2J3JBIRHSU0RHPC3V39XTO3EDOS3LKK0NQCUMZ4BI6U7KKI1785U19YM73DQGFKTADPSC2NUUED4TMAF94WE75WTISLF52FJSJGHOKJT4F1QVTJ6A3X8MVLE2JIGWYNM27B59MZA51E3XL3GY97IFS37X9MUC9YSNE26YB8ID6QZUKYQBQFM37THO4D5XUTDFH6T77ITNJYBVAKT');
call InsertCategory('HWZE9QNUC6EQRG65LRWO8MHIRRFPOECFQ01W08LE3JB95GQ00ASRJS85J2VNIM04HAHL68G0NZU8X4B7LN7Q3R9ENEN416EQC8VYDL96MEE32G1Y03H5H1WMKTEKDGJ3SJNBQ5UGMYNYNO9YZTOC8RXQQA04AUCC35GY0I2IH8B7GXI9FLVKXR1GPPUO8HWSMUC479HIUO31GIPJK67ZBFDCHE74QS319ZSTKWCMKLCQFXD02PF5GTBDL5XEEL6');
call InsertCategory('Z86ZTZCJ5MMIJXY9OEVMSOFJJFAE5LZ9Z5TCVSF2AESS4TDKAI8QMPZ4FJIOV5D7Y2PF86VP98QFLM0ABB677WOOYPVKECCO5GBXHEHJ8J2S96YUD9RB6LIU9285MSVSW76OZF5MEYJU18ZTXG5LI9K1QI7VABYBX96XNTLNINFO1IQ8476N1IW9SOXH8JB4K4C4LCA14YU83MCPSODHTO58GB7KHGQWJ5O6VBLD7UMIC922HGZD2PFI3YZ2BGK');
call InsertCategory('5BRXPPCY7I27PRVPH7ZRNGBMG6WAU76IXC8JXDOOOA4MMN1FZW5UHV3I1QFFGL6YYG90UTX167UE92RW53UXEECBUQLVF9VVX5QD75FWEM9DLJE0593ZEVSF0C1IUWOX5NWOXIJE1YZFN14LRPKHUW70W8U8SBKAQ7F59XWB2WL4GKITRL2768W6ILIXEETZSHZBO7VMLU4SC7MDGUZ4L7R2FLNFB40Q1A2OL5SB5FDDRCBSDPCHT32N97NX2LZ');
call InsertCategory('A6041A7KA2B7Z7U8AR4Y5HS1LR8L0AFGJSNTWYI5BZV1028NEX2OYBQITHYR22DIQULCQ5FSD02DOQNYK72IAHFZYYZUKOMWW4ILPAM1RR38MJN88VZX43DVLX58YZ5ENX4MX1Z340Y4C7ARLR4FH622TALW84AHJ4TNICJVOOGP5FOQJHVM8P6XF9F1DYG6X7KZLRXN2MODDQ4KCDRZ5E6MLD3BQVE5QAQFIRNQYJSJF93Q6PV8M98A9AQN3UU');
call InsertCategory('IOWRGCCM36ZXCNTZ0IU77JYD5O0BVLZQ4DO3BAX1M94RWACGA53JTN6DUNCEQGUQE2XUTYLLATTHIN91G1HXKP51IEV0Z0JKJICQB2OK1JQ3J3M1260USHXTTW41MIVTG1P76FSPAR0FWCFVU7J2SLFRLK7R0NAFQX1R8EKZZ5TE8H9U27W3E69HTYPY7ORHPMY9AI0J25883YV7NW997RKGKVD5NANY1RT0CIY7A7J1WWZNKYNZOKTKCBELM95');
call InsertCategory('KHWC6IXW303CJELU34KLYCQIF59Y45FEMX0FGZST2G1D0ZY8RNEIUMFZSQQT8U4V3P5SS0HZDKD51M5RP1L3WPEYCHP12OM0GN7NGV6JS3FWZSDFYFJT9X9G85MM5BG91KR8PXMP7E6QY4P0TLRJ1ZOKY5EZ6AF3C0K84GHJGX1PBNXVZ18SAS9X64LM7W6FDDHBXZWMJ66GIAR3PTWF3D3TAQL73FQMV7SUBZPD1W26XLBLHCKJFZKY3OR1SOZ');
call InsertCategory('8H9L1O4GDERWA6DAAGRGB8I4VBVGGAF5M5R26WINJIFNYQDNN4OXUV9GWL27WN7UM06KGXTTLQ50Y4ZUC7320JHKZ7LR8H5EQD3TV3H4RAVN7KH18Y4JZN50VNOR4FOBHI3V3782JCSZIESPIR08UR4JK84E9PPXTSLATII4FKCCURFX5QAY5RQTZ6A8R0G1RYZL4V06T367MGD451ABUBXZMHN4UGZ5IH8WV3OD8LXY34QYWF6ACTJ36I62G7J');
call InsertCategory('S0FP7ZFPVQWJXZ9XVR88K6LTJE5NC21IGU9DB3V80UG5C8Y7XRSRWB4LLCGDRXTRCA0C7APZUJ0HK954L0A24DQXQFYHOUCTNHWRE6V93JHLA8TQKMOH90KFYX8UKMV7NY7ZRA3YN7U0EYAACSHJMS3ONP1XUU433YRZ4NR5VUUFLPFXA63LWBW64DUWMZH2FHPWHOSWC38ALX0U1JEH5EPOLWO0T3P61I76JSEBG6K5LDHCUZ701TJGF7XCG7X');
call InsertCategory('V9KPF87T5PRGWD3RMR4MJYKBXSVIDEN7DYQST83BRPGNJBN2U8UOWNWTXT93DZI8T1HYEKN7FZP8SKNNS8L1IYGLRZBTN81203X4O50UNXCNEV0F2ZT7AXRJU0XJG0F1ZOB40PLRIDN5IJCUN8952TDOV61AKVG8ZZDF86NQXXGUU63Y42OPOOG5CAQJLNQWDY557XLT0WCGM01S2IRP8D2PY8IH7AHG3X3IEDKD4UEYFXK3486E1QWOZOQMQEV');
call InsertCategory('V9H4B6UJURFCNJVQZ0WBEUGE7NFG401B5U15ZXDKNN4L7YO202KP7AU1AZGMQR2JWD2YY2FEBODNA64L96TAGFS0MULZ60FRSP699LPZJGV3SNZEW3KDILS21HEJAN7C9CNEKCFNK2P32D2LZW8D2A854RW6H9UDG1YIND0UXVXIJHHPPWWYRWZBO7AUW6231DTCUOLFCV8FXLJTA0586XW9YH23IFRG46KNKYYV1TT5SA090M99EBN7CO2H288');
call InsertCategory('U9TUIWAWZI0RJQTYD6XRXIITDDKHT8I9IRDSNO4XXPKVOLZNS7DR1BC5XJUIW4FG8YCPU5SWWVKPUD6298WEC39VWYK062KI9REUSG05ECXY5M98OY70ZIGSYFNKIABYHH61TD0POJBJ9P5QKX21W705YBGGWUAVKFD6NUPWGVK91WTQQIKT4YECYDXG0ITKTC6NCQ05WRQS3B6YBGA7O2ZICBL49HSHXYME845T5VZ33919DPPBC7AGIOTQ4OM');
call InsertCategory('1570I4JP9LZV1K1CI52Y7VJX161APE45N2CGQR55ZND27WAK2YYKRJJ1Q2FDXGPOQK23ZZS1G9ECEM6LZ1DUONVUQYGW6OJVY0ZEX0RGMZL16SPG3QU5I3N2861ACLV91YGRL6LU1NEN69LZM6S7FS510IVQJ2TVSK15URRNE7UZ8N48CQKFM2O1CQ877GDNI99CQ3ZM97KH20RG17WJM9W50BI2IQDPT4K10FHUNKJ0ISXDILN7PW6GIKPRDJ4');
call InsertCategory('DFDZ2ZKXBTJXYNNYHTQG1CXPZ4X8I8T0UYRM7M0FBOHQRCWGS6Z6PQGKR1XKX81RQ3A64ZU3CQZFI4C3NFI3T7UHE5FXU177SBISW1P4VNO5E51RPWS12BRH3WX9W5I1URPLJPGVHCHFNVV51ZLAI0X86DG98G9EG6T98F6Y3DU20ZHJ3BP7OYWFJGHSVLBD4O89EAKFJLFXFG5C1GTDGJDQGVGI2HT1FA0V72WHW25AALTFWWRBMNKMBV4CZ8M');
call InsertCategory('COXY9JQOYN9XAX18P1YTMYU1ZIX5BIOG20P852WSUUMX30PQ8LT2YMOOV9OPZPNNN75Z2E728YSFDKYZH744SAB12F06IBO6OZBMICNH479VQ9WB68E4YRO5V0RZ18W4D5HU9QLZT2UGXXA4MS2O01MIW0Y79B1XBX2NGRJ0IBN51GJUG35RKAJ6CXVQO9RVCWJ1BT9W8JERWUJ8VJEM7JSRGNVD5TANUGCX2K6WY5FE2HLJ9WCGO4XH7F30GS0');
call InsertCategory('OAOZJR3JC2ETW0GAGZT6SZ2FMG0BU1OWRSL4NN0HFAAFOQSC4XMIWCB4OXTEOFM5VIKBCK520WJN8V2R4KO4A6ENKCNYISG0DPH17DFDUH2EHEL6MJPXYQ6ZDOOPZ3X9ZJTI0PIDH1K8N36WW5T4DV28QKL8D8S0H4437AC31WHCIYRT1S9L0I02OKW8DH2LQQ82GZ2DKCGGZOIFLO3QT2J0E0Q09O52I4QAPDKPFD0I1AM9TOS5XS8I9SLQ22M');
call InsertCategory('2CRVAFAQERZGSZ1XO7O9JEEESYQYNM9GIJHN5FVXIBF52FDMPG6B6ZK1RIJZRET1OX9CHKBXL6SDV2JLZINZDY3M2CRBUWAUAMWCSOLLUJCEB9J9LYBL55TWGN9E3Q1H6EUWB03H4CQ79Q8TZC5CTH918VO140R2ECCIHBJ3CTVROSI54A02JMQ3VDP4FJWVIPAYB3Q1MX0D2DN5REB3F5FWDTF77B0MMCJYE4FMH63211J0LV7C2IIQ759FJV5');
call InsertCategory('WTFY1ZXPR5IDVVZ2UD6QC57VD7YXPV0OBIIAXE3T5LFEE3RS0Y09Y815BZB6QMV4ZVT5OQS37VDE1VLE9H9INIY8Q6018NI5CXXAA5A3PTCW6U6HGSS1XTJAOQ4JS4MLSWBORK95LFTTXLH867NZG01RJGIL92YC889B57FP2X1MVGMAQZJG9HPSE9NJER6HG55PKT2FL2NB31QXV2VE7TLJ45WJ1INYL4YOG9YGOWZWIEJ1DCZRMEO48K9KA6J');
call InsertCategory('8EJT1Q441M6S9WTJDK8BJSCHCNEQ2YOLDGZ71OQVUVGFOMJC96EAJN3R9MJ0LEEBY731K6NB9YYAL0OKZ69ULOFDQW2ZMO3A9RDALP8SIQ743AG6CD1DN473B6MXX2MC93WN9V2RI7CM5OKDADNGNAO1SX7B6PGPAHINAIRDFX0ND2NGJYQL3873SSL2P3UB1H92T24LIAY4T619IFXIO97OY7VU1EE4TUYXECNDQHB61RAC83UPOFMBZFDCFFW');
call InsertCategory('M4K6DXFZ8BAIHLVQI7U458KE5NA53YES985OIFBQKGA2PJBSKAD1W0VIDV871SL98JSKY92IS0XLMUZCAJ7GE98O3W426G6PAYU2840RXOCX6RTEIDU6JCXLV3IBBU2SXBZ8QM4WUV4LJUSWCO2RKONAQS4NBSV265JB2WUXRCWEYSPCUSJCOPH1EF1USEL22VAH8UY0VM6AMF23GPB03M4MZWMURBBD2NYLJXZIDFF7VC7XA1HZPNTGSZLQJLS');
call InsertCategory('GCZR6LCASU1SM400RDBZJR2OLUJJJ5PLZ39M7LCH59563Z658VJ4MW8BY9VV0UVWCG10IGJ6NX5MAI6XJTPU7C0FRE14Q30I8LR9K6TCZKP8MBLP4JFD00AWZ7WNGTR0MRZ7RKGGTBTVJNDKWN6IWFA7LYNWKITW6NZ8R8HKPQGFNOWRYQSQ95SPG6M2AUB7P9OP1DQ5WY6KPXZHEM5XSHL26FIAE0RPB2X3VNN3DWRKKKH2XGBYB44R5YTXO52');
call InsertCategory('DCOTX9UYH97E7I6OHX1L3J4GMXTEBJQ21ICF7C4G36OPQ2XR5VBCRRADCCGZ2JU4YFTD1ZNTW4PWIVJOIC47D3KYE538JP8AMKVFP62B9Q59A5423N9ABV23JEQ1XRWBQZ4TGEMJ5KJCBEYGUS8QTCEB9S9CSKRYZHIOEDFCQUSIZS3QPX12UJTUE8JO0U9CSRRKSCIZ2JFZ1Y369MH8BA24TJ211TA22BE604U7O2E3HVCYZUODRR6DP79X3QS');
call InsertCategory('GS8FWTBX45OWJJZ0BFB17V81HF04DY721514N1I8SRNDIPOZ222E72M2CKSJ35VP61LFLJVWWCH6Y09ZCX0YLO8QI6MZU4CVI1SM3IZAFL22XSP9RLD5FER8ZE1XKVLK4L349C01RBK5UOKGNWSJKN4ITKDUHW14QRT2HYS2TLB4OBGJOPG9OZ0QYDQ0WFJPOWVIG3MJXBSKQWLVQG6ZHZTBPI3JD3L7SERSFXELEPOQZ0OM5GA21BGRGHTKJCR');
call InsertCategory('8H50STAIP3WLJQLAIAT4T0MJZ12STA9K4ORE191OHFLI4E8FDA3G3PCWIT0U9EOJ7ML710RTA5COQ093BRRWQVW7ZN2CDBHS4QN9R1KH70N1CK2YHA6H994TP6G5VLVKKOPE7TYLFOE7YNIP77OFJE34BXNICXHXT0PYLP5KL0TPVBCRD1E0JWNUV4OXKZ12DAERVB6Q6ZYXV9TVFS7M3K5PGHXJ6R9F3I4OTUK6IMBFJXVLXOME4Z6AXWYLU8F');
call InsertCategory('8RHNEDWAEX1EQLONE39SSMD3X5ZHZ4XMJ0863HTQLXH0A7GYFON0TECQ7Q27LEO5UP1R8YDIQCHXBHGO125P1Q51MMTWX5N3TUGN7711R1W7ASPVPRZYGBCIYXVDVZRX57N8PAVXO37U033XJDQFJ554IH90SS15AR53HAISG284DHJ2YBIFDPX274OHMUAZV6Y7M3GEDIQ9Y14O94NRTTTHTQ0GWNX79CXP4WT7FLKOHM1NNFGPDJV332XF7UA');
call InsertCategory('7O3396VM6LR046LIMJY1PK6Y0FBYQB9FMDMIUU5T65A3OVZQ0XWQLPYU88FFMBE6MPH6KN9QHUMVS58QTNKU05IBGH8NFL1I06VU2CICJXM9K08II0TYT6SN3RP5HGLGTZ4ASDIJZE1XQATTVIVVCNZ6PBD0S099ESBIG6Z4IR0K8KVWZ8ZYQ1E7ZQV0YZZZ6J4D4XDXL5S252LFNRM60YQT112MVPNCLWKKRJITZ53CK5IJWGWU2ONPT14KCRD');
call InsertCategory('E6HLWGRSQVC34GNFUWFB99F9YUZ4HRMKWV120OFN9US4KIPWRZE30DYRJ5WRIYFDNIBHAZ3GDBVWHOITPKXL8AZP94OKQ7K1ZPE8ANU3TAZE4PDJN8ROND0RTGX4NY5IKKWQSJ1S615NM1JIBCSULGJB8GFJ2Z6E5T9LS4QEDDRR8CUKL58GVD6D8AX3NSK0M8171N5ZU373WD0DE52WZG14BD0II6STNN9H0FCSLFNONYYPJVJ2TI7SBJTDYAQ');


# Concurrency test on InsertLanguage stored procedure: 50 random test cases
call InsertLanguage('EPBO0');
call InsertLanguage('UM2VT');
call InsertLanguage('BAPQU');
call InsertLanguage('3F9DI');
call InsertLanguage('M12NS');
call InsertLanguage('NQLE7');
call InsertLanguage('KV2HF');
call InsertLanguage('PNMMG');
call InsertLanguage('KQSJE');
call InsertLanguage('OGNMJ');
call InsertLanguage('RBBZB');
call InsertLanguage('F6UBB');
call InsertLanguage('04ATC');
call InsertLanguage('AE26A');
call InsertLanguage('4WVF3');
call InsertLanguage('VPZQC');
call InsertLanguage('H4SXA');
call InsertLanguage('V4IO4');
call InsertLanguage('LAJNR');
call InsertLanguage('F28KX');
call InsertLanguage('L0M6K');
call InsertLanguage('3K174');
call InsertLanguage('1Y5U0');
call InsertLanguage('4FNI8');
call InsertLanguage('4CEZL');
call InsertLanguage('WSYS5');
call InsertLanguage('2P4VR');
call InsertLanguage('WF0BH');
call InsertLanguage('EYJ35');
call InsertLanguage('85X9O');
call InsertLanguage('02L5G');
call InsertLanguage('QV7WC');
call InsertLanguage('A8C46');
call InsertLanguage('SU9DH');
call InsertLanguage('FG5DT');
call InsertLanguage('OWAZM');
call InsertLanguage('8YO2T');
call InsertLanguage('6D0DC');
call InsertLanguage('NMRYQ');
call InsertLanguage('97ZPE');
call InsertLanguage('52L5X');
call InsertLanguage('DCCJQ');
call InsertLanguage('H6SGN');
call InsertLanguage('Y2VIW');
call InsertLanguage('7KRES');
call InsertLanguage('HCIV1');
call InsertLanguage('W7U7A');
call InsertLanguage('P7XPH');
call InsertLanguage('TYGSJ');
call InsertLanguage('6KGVX');



call DeleteLanguage('FG5DT');
call InsertLanguage('FG6DT');