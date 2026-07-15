# Authenticator

A simple command-line utility for generating Time-based One-Time Passwords (TOTP) and automatically copying them to your clipboard.

## Features

- Generate TOTP tokens using Base32 encoded secrets.
- Support for multiple hash algorithms (SHA1, SHA256, SHA512).
- Customizable time step and token length.
- Automatic copy-to-clipboard functionality for seamless logins.

## Prerequisites

- [.NET 10.0 SDK](https://dotnet.microsoft.com/download)
- NuGet dependencies:
  - `OtpNet`
  - `TextCopy`

## Installation & Building

1. **Clone the repository:**
   ```bash
   git clone <repository-url>
   cd Authenticator
   ```

2. **Build the single executable:**
   Run the command corresponding to your operating system to generate a standalone binary:

   **For Windows (x64):**
   ```bash
   dotnet publish -c Release -r win-x64 --self-contained true /p:PublishSingleFile=true
   ```
   The file `Authenticator.exe` will be generated in `bin/Release/net10.0/win-x64/publish/`.

   **For Linux (x64):**
   ```bash
   dotnet publish -c Release -r linux-x64 --self-contained true /p:PublishSingleFile=true
   ```
   The binary `Authenticator` will be generated in `bin/Release/net10.0/linux-x64/publish/`.

## Running the Application

### Via Command Line (CLI)
Navigate to the output folder and run:

**Windows:**
```bash
Authenticator.exe --secret <YOUR_BASE32_SECRET> [options]
```

**Linux:**
```bash
chmod +x Authenticator
./Authenticator --secret <YOUR_BASE32_SECRET> [options]
```

### Via Windows Shortcut (Recommended)
For quick access without opening a terminal every time:
1. Right-click the generated `Authenticator.exe` and select **Create shortcut**.
2. Move the shortcut to your desktop or a preferred folder.
3. Right-click the shortcut and select **Properties**.
4. In the **Target** field, append your secret and options. 
   
   **Example Target:**
   ```text
   "C:\Path\To\Authenticator.exe" --secret JBSWY3DPEHPK3PXP --mode 1 --totpSize 6
   ```
5. Click **OK**. Now, just **double-click** the shortcut, and the token will be automatically copied to your clipboard.

## Usage

Run the application via the command line, providing your secret key as an argument.

```bash
Authenticator --secret <YOUR_BASE32_SECRET> [options]
```

### Required Arguments

- `--secret <value>`: The Base32 encoded secret string used to generate the TOTP.

### Optional Arguments

| Option | Description | Default |
| :--- | :--- | :--- |
| `--step <number>` | The time step size in seconds. | 30 |
| `--mode <number>` | Hash algorithm: 1 = Sha1, 2 = Sha256, 3 = Sha512. | 1 |
| `--totpSize <number>` | The number of digits in the generated TOTP. | 6 |

## Example

```bash
Authenticator --secret JBSWY3DPEHPK3PXP --mode 1 --totpSize 6
```

Once executed, the generated token will be  automatically copied to your system clipboard.