# .NET Aspire 專案 - Web0720

這是一個使用 .NET Aspire 建立的 .NET 9 分散式應用程式，展示了現代化、雲端就緒的架構。本應用程式包含後端 API、前端網頁應用程式以及支援性的基礎設施元件。

## 專案結構

此解決方案包含以下專案：

### 核心專案
- **Web.API**：提供 RESTful 端點進行資料存取的 ASP.NET Core Web API。
- **Web.View**：使用 Web.API 服務的 Razor Pages 前端應用程式。
  - Angular js 、Bootstrap、jQuery 等前端技術。

### Aspire 基礎架構專案
- **Web0720.AppHost**：協調部署和服務發現的 .NET Aspire 應用程式主機。
- **Web0720.ServiceDefaults**：用於健康檢查、遙測和彈性模式的通用服務配置。

### 測試專案
- **Web.View.UnitTest**：Web.View 專案的單元測試。
- **Web.View.EtoE.TEST**：應用程式的端到端測試。

## 系統架構

```
┌────────────────────┐
│                    │
│   Web0720.AppHost  │
│ (Aspire 協調層)     │
│                    │
└────────┬───────────┘
         │
         │ 管理
         ▼
┌─────────────────┐      ┌─────────────────┐
│                 │      │                 │
│    Web.View     │?────?│     Web.API     │
│  (Razor Pages)  │ HTTP │  (REST API)     │
│                 │ APIs │                 │
└─────────────────┘      └────────┬────────┘
                                  │
                                  │ 存取
                                  ▼
                         ┌────────────────────┐
                         │                    │
                         │   NorthWind 資料庫  │
                         │   (SQL Server)     │
                         │                    │
                         └────────────────────┘
```

## 使用的技術

- **.NET 9**：用於建構應用程式的最新版 .NET。
- **.NET Aspire**：用於建構分散式應用程式的雲端就緒技術堆疊。
- **Entity Framework Core**：用於資料庫存取的 ORM。
- **Swagger/OpenAPI**：API 文件和客戶端生成。
- **ASP.NET Core Razor Pages**：伺服器端 UI 框架。
- **服務發現**：自動服務註冊和發現。
- **健康檢查**：用於應用程式健康監控的端點。
- **OpenTelemetry**：分散式追蹤和指標收集。

## 資料流程

1. **Web0720.AppHost** 協調並管理服務。
2. **Web.View**（前端）使用生成的 Swagger 客戶端向 **Web.API** 發出 HTTP 請求。
3. **Web.API** 處理這些請求，與 NorthWind 資料庫互動，並返回回應。
4. OpenTelemetry 提供整個應用程式堆疊的可觀測性。

## 設定與配置

### 先決條件
- .NET 9 SDK
- 具有 NorthWind 資料庫的 SQL Server LocalDB 或 SQL Server 實例

### 資料庫設定
本應用程式使用 Entity Framework Core 的 Database-First 方法：

```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet ef dbcontext scaffold "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=NorthWind;Integrated Security=True;..." Microsoft.EntityFrameworkCore.SqlServer -o Models -c NorthWindDbContext
```

### 執行應用程式
1. 設定 **Web0720.AppHost** 作為啟動專案。
2. 按 F5 啟動應用程式。
3. Aspire 儀表板將會啟動，顯示所有服務的狀態。

## API 文件
Web.API 包含 Swagger UI，用於瀏覽和測試 API 端點：
- 在開發模式下，可在 Web.API 服務的根 URL 訪問。
- 提供所有 API 端點的互動式文件。

## 測試
- **單元測試**：位於 Web.View.UnitTest 專案中。
- **端到端測試**：位於 Web.View.EtoE.TEST 專案中。(尚未實踐) 預計使用Playwright

## 期望
- 透過prompt方式，建立合適從的View到測試驗收一整個流程的產生