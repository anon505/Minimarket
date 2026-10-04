; Installer System POS (Point Of Sale) (Inno Setup 6)
; Build: ISCC.exe installer\Minimarket.iss  (setelah build Release & unduh MSI MariaDB ke installer\redist)
; Logika database dijalankan POS_BetterMoney.exe (mode --cek-mysql / --setup-server / --setup-client, lihat modesetup.vb)

#ifndef AppVersion
  #define AppVersion "1.0.0"
#endif
#ifndef MariaDBMsi
  #define MariaDBMsi "mariadb-11.8.9-winx64.msi"
#endif
#define AppName "System POS (Point Of Sale)"
#define AppShortName "System POS"
#define AppExe "POS_BetterMoney.exe"
#define FirewallRule "BetterMoney POS Database"
#define NamaDatabase "bettermoney_pos"

[Setup]
AppId={{8C1F5E2A-6B7D-4C3E-9A1F-2D5B7E9C4A10}
AppName={#AppName}
AppVersion={#AppVersion}
AppPublisher=BetterMoney
DefaultDirName={autopf}\BetterMoney
; selalu tawarkan folder BetterMoney, bukan folder instalasi lama dengan AppId yang sama
UsePreviousAppDir=no
DefaultGroupName={#AppShortName}
DisableProgramGroupPage=yes
PrivilegesRequired=admin
ArchitecturesInstallIn64BitMode=x64compatible
OutputDir=..\dist
OutputBaseFilename=SystemPOS-Setup-{#AppVersion}
Compression=lzma2
SolidCompression=yes
WizardStyle=modern
WizardSizePercent=120
UninstallDisplayIcon={app}\{#AppExe}

[Languages]
Name: "en"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "Buat shortcut di Desktop"

[Dirs]
; koneksi.txt & config.txt (lihat Module1.lokasifile) harus bisa ditulis user biasa
Name: "{commonappdata}\BetterMoney"; Permissions: users-modify; Flags: uninsneveruninstall

[Files]
Source: "..\Minimarket\bin\Release\*"; DestDir: "{app}"; Excludes: "*.pdb,*.xml,*.vshost.*"; Flags: ignoreversion
Source: "..\minimarket_db.sql"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\logoku.jpg"; DestDir: "{app}"; Flags: ignoreversion
Source: "redist\{#MariaDBMsi}"; Flags: dontcopy

[Icons]
Name: "{autoprograms}\{#AppShortName}"; Filename: "{app}\{#AppExe}"
Name: "{autodesktop}\{#AppShortName}"; Filename: "{app}\{#AppExe}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#AppExe}"; Description: "Jalankan {#AppShortName}"; Flags: postinstall nowait skipifsilent

[Code]
var
  ModePage: TInputOptionWizardPage;
  ServerDbPage: TInputQueryWizardPage;
  ServerAppPage: TInputQueryWizardPage;
  ClientPage: TInputQueryWizardPage;
  LisensiPage: TInputQueryWizardPage;
  ProgresPage: TOutputProgressWizardPage;
  MySQLSudahAda: Boolean;
  AppSudahDiekstrak: Boolean;

function IsServer: Boolean;
begin
  Result := ModePage.SelectedValueIndex = 0;
end;

function DotNet48Terpasang: Boolean;
var
  Release: Cardinal;
begin
  Result := RegQueryDWordValue(HKLM, 'SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full', 'Release', Release) and (Release >= 528040);
end;

function InitializeSetup: Boolean;
begin
  Result := DotNet48Terpasang;
  if not Result then
    MsgBox('{#AppName} membutuhkan .NET Framework 4.8.' + #13#10 +
      'Pasang dari https://dotnet.microsoft.com/download/dotnet-framework/net48 lalu jalankan installer ini lagi.',
      mbCriticalError, MB_OK);
end;

function AngkaValid(S: String): Boolean;
var
  i: Integer;
begin
  Result := Length(S) > 0;
  for i := 1 to Length(S) do
    if (S[i] < '0') or (S[i] > '9') then
      Result := False;
end;

{ sama dengan koneksidb.namavalid: huruf, angka, underscore, maks 32 }
function NamaValid(S: String): Boolean;
var
  i: Integer;
  c: Char;
begin
  Result := (Length(S) > 0) and (Length(S) <= 32);
  for i := 1 to Length(S) do
  begin
    c := S[i];
    if not (((c >= 'a') and (c <= 'z')) or ((c >= 'A') and (c <= 'Z')) or ((c >= '0') and (c <= '9')) or (c = '_')) then
      Result := False;
  end;
end;

function Gagal(Pesan: String): Boolean;
begin
  MsgBox(Pesan, mbError, MB_OK);
  Result := False;
end;

// {#AppExe} disalin sementara ke folder tmp agar bisa dipakai mengecek koneksi sebelum instalasi.
// ExtractTemporaryFiles menaruh file di {tmp}\{app}\ (folder bernama "{app}" apa adanya, bukan path instalasi)
function AppSementara: String;
begin
  if not AppSudahDiekstrak then
  begin
    ExtractTemporaryFiles('{app}\*');
    AppSudahDiekstrak := True;
  end;
  Result := ExpandConstant('{tmp}\') + '{app}\{#AppExe}';
end;

{ Jalankan {#AppExe} <Mode> <file.ini>. Isi berisi baris key=value (termasuk password);
  file ini dihapus aplikasi setelah dibaca. Hasil: exit code (-1 jika exe tidak bisa dijalankan),
  Pesan = isi <file.ini>.hasil }
function JalankanApp(Exe, Mode: String; Isi: TStringList; var Pesan: String): Integer;
var
  Ini: String;
  Baris: TArrayOfString;
  Hasil: AnsiString;
  i, Kode: Integer;
begin
  Pesan := '';
  if not FileExists(Exe) then
  begin
    Pesan := 'File ' + Exe + ' tidak ditemukan.';
    Result := -1;
    exit;
  end;
  Ini := ExpandConstant('{tmp}\setup.ini');
  SetArrayLength(Baris, Isi.Count);
  for i := 0 to Isi.Count - 1 do
    Baris[i] := Isi[i];
  SaveStringsToUTF8File(Ini, Baris, False);
  DeleteFile(Ini + '.hasil');
  if not Exec(Exe, Mode + ' "' + Ini + '"', '', SW_HIDE, ewWaitUntilTerminated, Kode) then
  begin
    Pesan := 'Gagal menjalankan ' + Exe + ': ' + SysErrorMessage(Kode);
    Kode := -1;
  end
  else if LoadStringFromFile(Ini + '.hasil', Hasil) then
    Pesan := String(Hasil);
  { jaga-jaga jika aplikasi berhenti sebelum sempat menghapus file berisi password }
  DeleteFile(Ini);
  DeleteFile(Ini + '.hasil');
  if (Kode <> 0) and (Pesan = '') then
    Pesan := '{#AppExe} berhenti dengan kode ' + IntToStr(Kode) + '.';
  Result := Kode;
end;

procedure InitializeWizard;
begin
  ModePage := CreateInputOptionPage(wpWelcome,
    'Jenis Instalasi', 'Komputer ini akan dipakai sebagai apa?',
    'Pasang SERVER lebih dulu di satu komputer pusat, lalu pasang CLIENT di komputer kasir lainnya.',
    True, False);
  ModePage.Add('Server - komputer pusat (memasang database MariaDB + aplikasi)');
  ModePage.Add('Client - komputer kasir (aplikasi saja, terhubung ke server)');
  ModePage.SelectedValueIndex := 0;

  { tiap halaman disisipkan tepat setelah ModePage -> urutan: Mode, Lisensi, Client, Server DB, Server App
    (yang tidak dipakai dilewati) }
  ServerDbPage := CreateInputQueryPage(ModePage.ID,
    'Database Server', 'Password administrator (root) database',
    'Jika MariaDB/MySQL sudah terpasang di komputer ini, isi password root yang sudah ada. ' +
    'Jika belum, MariaDB akan dipasang dengan password ini. Simpan password ini baik-baik.');
  ServerDbPage.Add('Port database:', False);
  ServerDbPage.Add('Password root:', True);
  ServerDbPage.Add('Ulangi password root:', True);
  ServerDbPage.Values[0] := '3306';

  ServerAppPage := CreateInputQueryPage(ServerDbPage.ID,
    'Akun Aplikasi', 'User database untuk aplikasi {#AppShortName}',
    'User ini dipakai aplikasi di komputer server dan semua komputer kasir untuk terhubung ke database. ' +
    'Catat username dan password ini untuk memasang client. Akun ini terpisah dari akun login aplikasi.');
  ServerAppPage.Add('Username aplikasi:', False);
  ServerAppPage.Add('Password aplikasi:', True);
  ServerAppPage.Add('Ulangi password aplikasi:', True);
  ServerAppPage.Add('Nama toko:', False);
  ServerAppPage.Values[0] := 'superadmin';

  ClientPage := CreateInputQueryPage(ModePage.ID,
    'Koneksi ke Server', 'Data komputer server',
    'Isi IP komputer server (ditampilkan di akhir instalasi server) dan akun aplikasi yang dibuat saat memasang server. ' +
    'Koneksi dites saat klik Next.');
  ClientPage.Add('IP server (contoh 192.168.1.10):', False);
  ClientPage.Add('Port database:', False);
  ClientPage.Add('Username aplikasi:', False);
  ClientPage.Add('Password aplikasi:', True);
  ClientPage.Add('Nama toko:', False);
  ClientPage.Values[1] := '3306';
  ClientPage.Values[2] := 'superadmin';

  { license key hanya untuk server: diikat ke ID mesin komputer server, client membaca lisensi dari database server }
  LisensiPage := CreateInputQueryPage(ModePage.ID,
    'Lisensi', 'License key komputer server',
    'Kirim ID mesin di bawah ke BetterMoney (klik kotaknya, Ctrl+A lalu Ctrl+C untuk menyalin). ' +
    'Tempel license key yang Anda terima, lalu klik Next. ' +
    'Jika belum punya key, klik Cancel dan jalankan installer ini lagi setelah key diterima.');
  LisensiPage.Add('ID mesin komputer ini:', False);
  LisensiPage.Add('License key:', False);
  LisensiPage.Edits[0].ReadOnly := True;

  ProgresPage := CreateOutputProgressPage('Memasang Database', 'Mohon tunggu, proses ini bisa memakan beberapa menit.');
end;

function ShouldSkipPage(PageID: Integer): Boolean;
begin
  Result := False;
  if (PageID = LisensiPage.ID) or (PageID = ServerDbPage.ID) or (PageID = ServerAppPage.ID) then
    Result := not IsServer
  else if PageID = ClientPage.ID then
    Result := IsServer;
end;

function CekServerDb: Boolean;
var
  Isi: TStringList;
  Kode: Integer;
  Pesan, Port: String;
begin
  Port := Trim(ServerDbPage.Values[0]);
  if not AngkaValid(Port) then
  begin
    Result := Gagal('Port harus angka.');
    exit;
  end;
  if ServerDbPage.Values[1] = '' then
  begin
    Result := Gagal('Password root tidak boleh kosong.');
    exit;
  end;
  if ServerDbPage.Values[1] <> ServerDbPage.Values[2] then
  begin
    Result := Gagal('Password root dan ulangannya tidak sama.');
    exit;
  end;
  if Pos('"', ServerDbPage.Values[1]) > 0 then
  begin
    Result := Gagal('Password root tidak boleh mengandung tanda kutip (").');
    exit;
  end;

  Isi := TStringList.Create;
  try
    Isi.Add('host=localhost');
    Isi.Add('port=' + Port);
    Isi.Add('user=root');
    Isi.Add('password=' + ServerDbPage.Values[1]);
    Kode := JalankanApp(AppSementara, '--cek-mysql', Isi, Pesan);
  finally
    Isi.Free;
  end;

  Result := True;
  if Kode = 0 then
  begin
    MySQLSudahAda := True;
    MsgBox('MySQL/MariaDB sudah berjalan di port ' + Port + ' dan password root benar.' + #13#10 +
      'Installer akan memakai database yang sudah ada (MariaDB tidak dipasang).', mbInformation, MB_OK);
  end
  else if Kode = 2 then
  begin
    MySQLSudahAda := False;
    { MSI MariaDB 10.5+ hanya bisa dipasang di Windows 10 / Server 2016 ke atas }
    if (GetWindowsVersion shr 24) < 10 then
      Result := Gagal('MariaDB membutuhkan Windows 10 / Windows Server 2016 atau lebih baru.' + #13#10 +
        'Pakai komputer lain sebagai Server, atau pasang MySQL/MariaDB sendiri lalu isi password root-nya di sini.')
    else if RegKeyExists(HKLM, 'SYSTEM\CurrentControlSet\Services\MariaDB') then
      Result := Gagal('Service MariaDB sudah terpasang tetapi tidak berjalan di port ' + Port + '.' + #13#10 +
        'Jalankan service MariaDB (services.msc) atau periksa port, lalu klik Next lagi.');
  end
  else if Kode = 1 then
    Result := Gagal('Sudah ada MySQL/MariaDB di port ' + Port + ', tetapi login root gagal:' + #13#10 + Pesan + #13#10#13#10 +
      'Isi password root MySQL yang sudah ada.')
  else
    { exe tidak ditemukan / crash (mis. .NET Framework 4.8 belum terpasang): bukan masalah MySQL }
    Result := Gagal('Pemeriksaan MySQL tidak bisa dijalankan:' + #13#10 + Pesan);
end;

function CekServerApp: Boolean;
begin
  if not NamaValid(ServerAppPage.Values[0]) then
    Result := Gagal('Username aplikasi hanya boleh huruf, angka, dan underscore (maks 32 karakter).')
  else if ServerAppPage.Values[1] = '' then
    Result := Gagal('Password aplikasi tidak boleh kosong.')
  else if ServerAppPage.Values[1] <> ServerAppPage.Values[2] then
    Result := Gagal('Password aplikasi dan ulangannya tidak sama.')
  else if Trim(ServerAppPage.Values[3]) = '' then
    Result := Gagal('Nama toko tidak boleh kosong.')
  else
    Result := True;
end;

function CekClient: Boolean;
var
  Isi: TStringList;
  Kode: Integer;
  Pesan: String;
begin
  if Trim(ClientPage.Values[0]) = '' then
  begin
    Result := Gagal('IP server tidak boleh kosong.');
    exit;
  end;
  if not AngkaValid(Trim(ClientPage.Values[1])) then
  begin
    Result := Gagal('Port harus angka.');
    exit;
  end;
  if (Trim(ClientPage.Values[2]) = '') or (ClientPage.Values[3] = '') then
  begin
    Result := Gagal('Username dan password aplikasi tidak boleh kosong.');
    exit;
  end;
  if Trim(ClientPage.Values[4]) = '' then
  begin
    Result := Gagal('Nama toko tidak boleh kosong.');
    exit;
  end;

  Isi := TStringList.Create;
  try
    Isi.Add('host=' + Trim(ClientPage.Values[0]));
    Isi.Add('port=' + Trim(ClientPage.Values[1]));
    Isi.Add('user=' + Trim(ClientPage.Values[2]));
    Isi.Add('password=' + ClientPage.Values[3]);
    Isi.Add('database={#NamaDatabase}');
    Kode := JalankanApp(AppSementara, '--cek-mysql', Isi, Pesan);
  finally
    Isi.Free;
  end;
  if Kode <> 0 then
    Result := Gagal('Tidak bisa terhubung ke server:' + #13#10 + Pesan)
  else
    Result := True;
end;

{ ID mesin ditampilkan saat halaman Lisensi dibuka }
procedure CurPageChanged(CurPageID: Integer);
var
  Isi: TStringList;
  Pesan: String;
begin
  if (CurPageID = LisensiPage.ID) and (LisensiPage.Values[0] = '') then
  begin
    Isi := TStringList.Create;
    try
      if JalankanApp(AppSementara, '--id-mesin', Isi, Pesan) = 0 then
        LisensiPage.Values[0] := Trim(Pesan)
      else
        MsgBox('ID mesin komputer ini tidak bisa dibaca:' + #13#10 + Pesan, mbError, MB_OK);
    finally
      Isi.Free;
    end;
  end;
end;

function CekLisensi: Boolean;
var
  Isi: TStringList;
  Kode: Integer;
  Pesan: String;
begin
  if Trim(LisensiPage.Values[1]) = '' then
  begin
    Result := Gagal('Isi license key dari BetterMoney. Kirim ID mesin di halaman ini untuk mendapatkannya.');
    exit;
  end;
  Isi := TStringList.Create;
  try
    Isi.Add('lisensi=' + Trim(LisensiPage.Values[1]));
    Kode := JalankanApp(AppSementara, '--cek-lisensi', Isi, Pesan);
  finally
    Isi.Free;
  end;
  if Kode = 0 then
  begin
    MsgBox(Pesan, mbInformation, MB_OK);
    Result := True;
  end
  else
    Result := Gagal(Pesan);
end;

function NextButtonClick(CurPageID: Integer): Boolean;
begin
  Result := True;
  if (CurPageID = ModePage.ID) and IsServer and not IsWin64 then
    Result := Gagal('Server membutuhkan Windows 64-bit (MariaDB hanya tersedia 64-bit).')
  else if CurPageID = LisensiPage.ID then
    Result := CekLisensi
  else if CurPageID = ServerDbPage.ID then
    Result := CekServerDb
  else if CurPageID = ServerAppPage.ID then
    Result := CekServerApp
  else if CurPageID = ClientPage.ID then
    Result := CekClient;
end;

{ MariaDB dipasang sebelum file aplikasi disalin, agar instalasi bisa dibatalkan bersih jika gagal }
function PrepareToInstall(var NeedsRestart: Boolean): String;
var
  Kode: Integer;
  Msi: String;
begin
  Result := '';
  if IsServer and not MySQLSudahAda then
  begin
    // jangan kirim ALLOWREMOTEROOTACCESS (nilai apa pun, termasuk 0, mengaktifkan root dari jaringan)
    ProgresPage.SetText('Memasang MariaDB {#MariaDBMsi} ...', '');
    ProgresPage.Show;
    try
      ExtractTemporaryFile('{#MariaDBMsi}');
      Msi := ExpandConstant('{tmp}\{#MariaDBMsi}');
      if not Exec(ExpandConstant('{sys}\msiexec.exe'),
        '/i "' + Msi + '" /qn /norestart SERVICENAME=MariaDB PORT=' + Trim(ServerDbPage.Values[0]) +
        ' PASSWORD="' + ServerDbPage.Values[1] + '"',
        '', SW_HIDE, ewWaitUntilTerminated, Kode) then
        Result := 'Gagal menjalankan pemasang MariaDB: ' + SysErrorMessage(Kode)
      else if (Kode <> 0) and (Kode <> 3010) then
        Result := 'Pemasangan MariaDB gagal (kode msiexec ' + IntToStr(Kode) + ').' + #13#10 +
          'Pastikan port ' + Trim(ServerDbPage.Values[0]) + ' tidak dipakai program lain, lalu jalankan installer lagi.';
    finally
      ProgresPage.Hide;
    end;
  end;
end;

procedure SetupServer;
var
  Isi: TStringList;
  Kode, KodeFw: Integer;
  Pesan, Port: String;
begin
  Port := Trim(ServerDbPage.Values[0]);
  Isi := TStringList.Create;
  try
    Isi.Add('port=' + Port);
    Isi.Add('rootpassword=' + ServerDbPage.Values[1]);
    Isi.Add('database={#NamaDatabase}');
    Isi.Add('appuser=' + ServerAppPage.Values[0]);
    Isi.Add('apppassword=' + ServerAppPage.Values[1]);
    Isi.Add('namatoko=' + Trim(ServerAppPage.Values[3]));
    Isi.Add('sqlfile=' + ExpandConstant('{app}\minimarket_db.sql'));
    Isi.Add('logo=' + ExpandConstant('{app}\logoku.jpg'));
    Isi.Add('lisensi=' + Trim(LisensiPage.Values[1]));
    Kode := JalankanApp(ExpandConstant('{app}\{#AppExe}'), '--setup-server', Isi, Pesan);
  finally
    Isi.Free;
  end;

  { izinkan komputer kasir mengakses port database }
  Exec(ExpandConstant('{sys}\netsh.exe'), 'advfirewall firewall delete rule name="{#FirewallRule}"',
    '', SW_HIDE, ewWaitUntilTerminated, KodeFw);
  Exec(ExpandConstant('{sys}\netsh.exe'), 'advfirewall firewall add rule name="{#FirewallRule}" dir=in action=allow protocol=TCP localport=' + Port,
    '', SW_HIDE, ewWaitUntilTerminated, KodeFw);

  if Kode <> 0 then
    MsgBox('Aplikasi terpasang, tetapi pengaturan database gagal:' + #13#10 + Pesan + #13#10#13#10 +
      'Perbaiki lewat menu Konfigurasi di aplikasi, atau jalankan installer ini lagi.', mbError, MB_OK)
  else
  begin
    if KodeFw <> 0 then
      Pesan := Pesan + #13#10#13#10 + 'Catatan: aturan firewall untuk port ' + Port + ' gagal dibuat. Buka port ini secara manual di Windows Firewall.';
    MsgBox('Server siap dipakai.' + #13#10#13#10 + Pesan, mbInformation, MB_OK);
  end;
end;

procedure SetupClient;
var
  Isi: TStringList;
  Pesan: String;
begin
  Isi := TStringList.Create;
  try
    Isi.Add('host=' + Trim(ClientPage.Values[0]));
    Isi.Add('port=' + Trim(ClientPage.Values[1]));
    Isi.Add('database={#NamaDatabase}');
    Isi.Add('appuser=' + Trim(ClientPage.Values[2]));
    Isi.Add('apppassword=' + ClientPage.Values[3]);
    Isi.Add('namatoko=' + Trim(ClientPage.Values[4]));
    Isi.Add('logo=' + ExpandConstant('{app}\logoku.jpg'));
    if JalankanApp(ExpandConstant('{app}\{#AppExe}'), '--setup-client', Isi, Pesan) <> 0 then
      MsgBox('Aplikasi terpasang, tetapi koneksi ke server gagal disimpan:' + #13#10 + Pesan + #13#10#13#10 +
        'Perbaiki lewat menu Konfigurasi di aplikasi.', mbError, MB_OK);
  finally
    Isi.Free;
  end;
end;

procedure CurStepChanged(CurStep: TSetupStep);
begin
  if CurStep = ssPostInstall then
  begin
    if IsServer then
      SetupServer
    else
      SetupClient;
  end;
end;
