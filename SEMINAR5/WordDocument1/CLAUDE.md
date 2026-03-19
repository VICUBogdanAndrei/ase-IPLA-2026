# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

This is a **Microsoft Word VSTO (Visual Studio Tools for Office) document-level add-in** written in C# targeting .NET Framework 4.7.2. It implements a product management/ordering form with a Romanian-language UI, allowing users to select products, specify quantities, and save to PDF.

## Build

Open `WordDocument1.slnx` in Visual Studio (2019+) and build normally, or use MSBuild from the project directory:

```bash
msbuild WordDocument1/WordDocument1.csproj
```

Build output goes to `WordDocument1/bin/Debug/` or `WordDocument1/bin/Release/`, producing:
- `WordDocument1.dll` — the add-in assembly
- `WordDocument1.docx` — the host Word document
- `WordDocument1.vsto` — deployment manifest

## Architecture

**Entry point:** `WordDocument1/ThisDocument.cs` — VSTO Document Host Item with `Startup`/`Shutdown` event handlers. This is where document-level initialization occurs.

**UI:** `WordDocument1/UserControl1.cs` — Windows Forms UserControl with:
- `cmbProduse` (ComboBox) — product selector
- NumericUpDown — quantity input
- "Adauga Produs" button — adds product to document
- "Salveaza PDF" button — saves document as PDF
- Document protection via password + form field protection

**Data model:** `Produs` class nested inside `UserControl1`:
- `Denumire` (string) — product name
- `Pret` (decimal) — price
- `Um` (string) — unit of measure

**Document structure:** `ThisDocument.Designer.xml` defines the content controls embedded in the Word document (plain text fields, a dropdown, and a date picker).

## Key Constraints

- Targets .NET Framework 4.7.2 — do not use APIs unavailable on this framework
- Signed with `WordDocument1_TemporaryKey.pfx` — required for VSTO deployment
- VSTO requires Visual Studio with Office development tools installed to build and debug
- No unit tests exist in this project
