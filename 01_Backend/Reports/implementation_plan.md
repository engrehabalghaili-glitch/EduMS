# Phase-9: Background Jobs (Hangfire) & Secure File Storage

The goal of this phase is to establish the infrastructure for processing asynchronous background tasks and securely managing file uploads within the Clean Architecture boundaries. 

## User Review Required
> [!IMPORTANT]
> - Hangfire will be configured with `Hangfire.InMemory` for this phase to ensure a rapid, self-contained development loop. This can easily be swapped to an Oracle or SQL Server storage provider in production.
> - File Storage will use local disk storage (e.g., an `Uploads` directory in the WebApi root or a designated configurable path).
> - The Hangfire Dashboard will be accessible locally for monitoring jobs. For production, we will need to secure it with an authorization filter.

## Open Questions
> [!NOTE]
> No immediate questions. If you have specific file types (e.g., only PDF and JPG) or a specific absolute path for the upload directory, please let me know. I will default to common safe extensions and a local `Uploads` folder.

## Proposed Changes

---

### Packages & Dependencies
Add required Hangfire packages to `EduMS.Infrastructure`.

#### [MODIFY] [EduMS.Infrastructure.csproj](file:///d:/EduMS-Unified-Workspace/EduMS.Backend/src/EduMS.Infrastructure/EduMS.Infrastructure.csproj)
- Add `<PackageReference Include="Hangfire.AspNetCore" Version="1.8.14" />`
- Add `<PackageReference Include="Hangfire.InMemory" Version="0.9.0" />`

---

### Application Layer (File Storage & Jobs)
Define the contracts and base job classes.

#### [NEW] [IFileStorageService.cs](file:///d:/EduMS-Unified-Workspace/EduMS.Backend/src/EduMS.Application/Interfaces/Infrastructure/IFileStorageService.cs)
- Define `UploadFileAsync`, `DeleteFileAsync`, and `GetFileAsync`.

#### [NEW] [ISystemHealthCheckJob.cs](file:///d:/EduMS-Unified-Workspace/EduMS.Backend/src/EduMS.Application/Interfaces/Infrastructure/ISystemHealthCheckJob.cs)
- Define a contract for a dummy background job to verify Hangfire functionality.

---

### Infrastructure Layer (Implementations)
Implement the file storage and job logic, and register them in DI.

#### [NEW] [FileStorageService.cs](file:///d:/EduMS-Unified-Workspace/EduMS.Backend/src/EduMS.Infrastructure/Services/FileStorageService.cs)
- Implement `IFileStorageService`.
- Include strict validation against malicious extensions and oversized files.
- Generate unique GUID-based filenames to prevent collisions.

#### [NEW] [SystemHealthCheckJob.cs](file:///d:/EduMS-Unified-Workspace/EduMS.Backend/src/EduMS.Infrastructure/Jobs/SystemHealthCheckJob.cs)
- Implement `ISystemHealthCheckJob` which simply logs a message to prove the pipeline works.

#### [MODIFY] [DependencyInjection.cs](file:///d:/EduMS-Unified-Workspace/EduMS.Backend/src/EduMS.Infrastructure/DependencyInjection.cs)
- Register `IFileStorageService` and `ISystemHealthCheckJob`.
- Configure `services.AddHangfire(c => c.UseInMemoryStorage())`.
- Configure `services.AddHangfireServer()`.

---

### WebApi Layer
Configure middleware and Hangfire Dashboard.

#### [MODIFY] [Program.cs](file:///d:/EduMS-Unified-Workspace/EduMS.Backend/src/EduMS.WebApi/Program.cs)
- Map the Hangfire dashboard (`app.UseHangfireDashboard()`).
- Enqueue a test fire-and-forget job or recurring job on startup to verify execution.

## Verification Plan
### Automated Tests
- `dotnet build` to verify clean compilation with 0 errors.

### Manual Verification
- Start the API and navigate to `/hangfire` to verify the dashboard loads.
- Ensure the `SystemHealthCheckJob` executes successfully in the Hangfire "Enqueued" or "Succeeded" tabs.
