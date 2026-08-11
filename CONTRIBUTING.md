# Contributing to SOACS Rampart

SOACS Rampart uses a controlled branch workflow so the `main` branch remains a stable portfolio/source baseline while development continues separately.

## Branch model

- `main` — stable reviewed baseline
- `develop` — integrated development
- `feature/<description>` — isolated feature work
- `fix/<description>` — defect corrections

New work should be performed in a feature or fix branch and merged into `develop` through a pull request. Tested changes are promoted from `develop` to `main` through a separate pull request.

## Current project status

Rampart is currently an early prototype / alpha foundation. The application shell, dashboard, navigation, branding, and project structure are present, while major operational functions remain under development.

Do not describe placeholder pages as implemented capabilities until working functionality exists and has been tested.

## Public repository rules

Do not commit operational or customer-specific network data, including:

- Real switch/router running configurations
- Site names or customer identifiers
- Production IP addressing schemes
- Usernames, passwords, enable secrets, keys, or certificates
- SNMP community strings or credentials
- TACACS/RADIUS secrets
- Private SSH keys
- Operational CKL/XCCDF files containing site/device details
- Backups, logs, reports, or exported configurations from fielded systems

Use sanitized examples or placeholders for testing and documentation.

## Development expectations

Before promoting a change toward `main`:

1. Build the solution in Release / Any CPU.
2. Verify the application launches without layout errors.
3. Check navigation and DPI behavior.
4. Test any configuration parsing or generation against sanitized examples.
5. Confirm no credentials, site data, or operational configuration are included.
6. Document known limitations in the pull request.

## Intended development direction

Planned Rampart capabilities include Cisco configuration import/generation, interface analysis, syntax validation, VLAN and routing workflows, STIG prechecks, deployment safeguards, backup/rollback, and engineering reports. These remain planned until implemented and tested in source.
