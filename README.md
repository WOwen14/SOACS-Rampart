# SOACS Rampart

**Network Engineering & Compliance Suite**

SOACS Rampart is a Windows desktop prototype intended to support Cisco configuration engineering, validation, hardening, and deployment workflows in disconnected or controlled environments.

> **Status:** Prototype / Alpha Foundation  
> **Current Source Baseline:** v1.0 Alpha Foundation  
> **Application Version:** 1.0.0.0  
> **Platform:** Windows  
> **Application:** Windows Forms  
> **Framework:** .NET Framework 4.8

---

## Purpose

Rampart is being developed as a mission-focused workspace for network engineers who need to build, review, validate, harden, and eventually deploy Cisco configurations without depending on cloud services or continuous internet access.

The project is currently an early software foundation. The application shell, navigation, dashboard, branding, DPI-aware layout, and page structure are present. Most operational network-engineering functions remain under development.

## Current Implementation

The v1.0 Alpha Foundation currently includes:

- Windows Forms application shell
- SOACS Rampart branding and splash experience
- DPI-aware startup sizing
- Dashboard framework
- Navigation structure for major engineering workflows
- Status bar and application-state placeholders
- Local/offline desktop architecture
- Visual foundations for device, configuration, compliance, deployment, and reporting workflows

The current dashboard exposes readiness areas for devices, syntax validation, STIG validation, deployment, and backups, but those functions are not yet implemented as operational capabilities.

## Planned Capabilities

Development is intended to add working functionality for:

### Device & Configuration Management

- Cisco device inventory
- Running-configuration import
- Configuration backup
- Model and interface discovery
- Approved configuration templates
- Variable-driven configuration generation
- Configuration comparison and review

### Interface & VLAN Engineering

- Automatic interface detection
- Layer 2 / Layer 3 classification
- Per-interface configuration workflows
- VLAN creation and removal
- Interface configuration validation

### Routing & Network Services

- Static routing
- OSPF / EIGRP / BGP workflows where applicable
- VRF handling
- Route validation
- Network-service configuration review

### Security & Compliance

- Configuration syntax validation
- Security-hardening checks
- STIG checklist import and mapped prechecks
- Manual-review identification
- AAA, SSH, SNMP, NTP, logging, banners, ACLs, and certificate review
- Compliance reporting

### Deployment

- Pre-deployment backup
- Configuration diff
- Controlled configuration push
- Post-deployment verification
- Rollback workflow
- Deployment records and engineering reports

## Architecture

Rampart is implemented as a C# Windows Forms application targeting **.NET Framework 4.8**.

The current Visual Studio project uses **Any CPU** and does not rely on external NuGet packages.

```text
SOACSRampart.sln
SOACSRampart.csproj
Program.cs
MainForm.cs
Theme.cs
SplashForm.cs
Pages/
    DashboardPage.cs
    PlaceholderPage.cs
Assets/
    RampartLogo.png
```

## Operational Security

This public repository must not contain real operational network data.

Do not commit:

- Production switch/router configurations
- Customer or site identifiers
- Operational IP addressing plans
- Passwords, enable secrets, keys, or certificates
- SNMP community strings
- TACACS/RADIUS secrets
- Device backups
- Fielded-system logs or reports
- Unsanitized compliance checklists containing device/site information

Use sanitized examples and placeholders for development and documentation.

## Development Workflow

```text
feature/* or fix/*
        |
        v
     develop
        |
   testing/review
        |
        v
       main
```

- `main` represents the stable reviewed source baseline.
- `develop` is used for integrated development.
- New work should be developed in feature/fix branches.
- Tested changes are promoted from `develop` to `main` through pull requests.

See [CONTRIBUTING.md](CONTRIBUTING.md) for repository and public-data rules.

## Current Development Direction

The immediate development objective is to move Rampart from its UI/application foundation into functional network-engineering capability, beginning with sanitized configuration import, interface analysis, configuration validation, and controlled configuration generation.

## About SOACS

Rampart is part of the SOACS software suite—a set of mission-focused applications developed around real operational workflows and disconnected-system requirements.
