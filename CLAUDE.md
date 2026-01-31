# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

SemanticBlazor is a Blazor component library implementing Semantic UI (Fomantic UI) components for ASP.NET Core Blazor applications. It provides 60+ reusable UI components with the `Sem*` naming convention.

## Build Commands

```bash
# Build entire solution
cd src
dotnet build SemanticBlazor.sln

# Build library only
dotnet build SemanticBlazor/SemanticBlazor.csproj

# Create NuGet package
dotnet pack SemanticBlazor/SemanticBlazor.csproj --configuration Release -o ./output

# Run demo web app (navigate to https://localhost:5001)
cd src/SemanticBlazor.Web
dotnet run
```

## Architecture

### Project Structure
- `src/SemanticBlazor/` - Core library (netstandard2.1)
- `src/SemanticBlazor.Web/` - Demo/documentation app (net8.0)

### Component Base Pattern
All components inherit from `SemControlBase` (`Components/Base/Common/SemControlBase.cs`), which provides:
- Common properties: Id, Class, Style, Visible, Enabled, Attributes
- `ClassMapper` for dynamic CSS class generation
- JSInterop integration via `IJSRuntime`
- Lifecycle tracking with `Rendered` flag

### Key Architectural Elements

**ClassMapper/StyleMapper** (`Mappers/`): Fluent API for building CSS class and style strings dynamically.

**JsFunc** (`JsFunc.cs`): Static helper for JavaScript interop calls to Semantic/Fomantic UI libraries. Categories include: Lists, Dropdown, Modal, Form, DateTimeInput, Validation.

**Enums** (`Enums.cs`): All UI enums (Color, Size, State, IconPosition, etc.) with `GetClass<T>()` helper to convert enum values to lowercase CSS class names.

**Services**:
- `NotificationService` - Event-based notification system
- `PackageInformationService` - Package metadata

### Component Categories
- Form: SemForm, SemFormField, SemInput, SemValidationMessage
- Selection: SemDropdownSelection, SemDropdownMultiSelection, SemCheckboxList, SemRadioButtonList
- Data Display: SemDataTable, SemDataList, SemPagination, SemCards
- Modal: SemModal, SemModalConfirmation
- Navigation: SemMenu, SemMenuItem, SemTabs
- Input Types: SemDateInput, SemDateTimeInput, SemTimeInput, SemActionInput

## Development Workflow

**Branching**: Feature branches → `dev` → PR to `master`

**CI/CD**: GitHub Actions workflows in `.github/workflows/`:
- Build.yml/DevBuild.yml - Build on push
- NugetPush.yml - Publish to NuGet on release
- AzureDeploy.yml - Deploy demo to Azure

## Frontend Dependencies

Bundled in `wwwroot/modules/`: jQuery, Semantic UI/Fomantic UI, Calendar plugin. Components use JSInterop to call these libraries.
