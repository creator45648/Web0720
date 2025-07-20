# .NET Aspire �M�� - Web0720

�o�O�@�Өϥ� .NET Aspire �إߪ� .NET 9 ���������ε{���A�i�ܤF�{�N�ơB���ݴN�����[�c�C�����ε{���]�t��� API�B�e�ݺ������ε{���H�Τ䴩�ʪ���¦�]�I����C

## �M�׵��c

���ѨM��ץ]�t�H�U�M�סG

### �֤߱M��
- **Web.API**�G���� RESTful ���I�i���Ʀs���� ASP.NET Core Web API�C
- **Web.View**�G�ϥ� Web.API �A�Ȫ� Razor Pages �e�����ε{���C
  - Angular js �BBootstrap�BjQuery ���e�ݧ޳N�C

### Aspire ��¦�[�c�M��
- **Web0720.AppHost**�G��ճ��p�M�A�ȵo�{�� .NET Aspire ���ε{���D���C
- **Web0720.ServiceDefaults**�G�Ω󰷱d�ˬd�B�����M�u�ʼҦ����q�ΪA�Ȱt�m�C

### ���ձM��
- **Web.View.UnitTest**�GWeb.View �M�ת��椸���աC
- **Web.View.EtoE.TEST**�G���ε{�����ݨ�ݴ��աC

## �t�ά[�c

```
�z�w�w�w�w�w�w�w�w�w�w�w�w�w�w�w�w�w�w�w�w�{
�x                    �x
�x   Web0720.AppHost  �x
�x (Aspire ��ռh)     �x
�x                    �x
�|�w�w�w�w�w�w�w�w�s�w�w�w�w�w�w�w�w�w�w�w�}
         �x
         �x �޲z
         ��
�z�w�w�w�w�w�w�w�w�w�w�w�w�w�w�w�w�w�{      �z�w�w�w�w�w�w�w�w�w�w�w�w�w�w�w�w�w�{
�x                 �x      �x                 �x
�x    Web.View     �x?�w�w�w�w?�x     Web.API     �x
�x  (Razor Pages)  �x HTTP �x  (REST API)     �x
�x                 �x APIs �x                 �x
�|�w�w�w�w�w�w�w�w�w�w�w�w�w�w�w�w�w�}      �|�w�w�w�w�w�w�w�w�s�w�w�w�w�w�w�w�w�}
                                  �x
                                  �x �s��
                                  ��
                         �z�w�w�w�w�w�w�w�w�w�w�w�w�w�w�w�w�w�w�w�w�{
                         �x                    �x
                         �x   NorthWind ��Ʈw  �x
                         �x   (SQL Server)     �x
                         �x                    �x
                         �|�w�w�w�w�w�w�w�w�w�w�w�w�w�w�w�w�w�w�w�w�}
```

## �ϥΪ��޳N

- **.NET 9**�G�Ω�غc���ε{�����̷s�� .NET�C
- **.NET Aspire**�G�Ω�غc���������ε{�������ݴN���޳N���|�C
- **Entity Framework Core**�G�Ω��Ʈw�s���� ORM�C
- **Swagger/OpenAPI**�GAPI ���M�Ȥ�ݥͦ��C
- **ASP.NET Core Razor Pages**�G���A���� UI �ج[�C
- **�A�ȵo�{**�G�۰ʪA�ȵ��U�M�o�{�C
- **���d�ˬd**�G�Ω����ε{�����d�ʱ������I�C
- **OpenTelemetry**�G�������l�ܩM���Ц����C

## ��Ƭy�{

1. **Web0720.AppHost** ��ըú޲z�A�ȡC
2. **Web.View**�]�e�ݡ^�ϥΥͦ��� Swagger �Ȥ�ݦV **Web.API** �o�X HTTP �ШD�C
3. **Web.API** �B�z�o�ǽШD�A�P NorthWind ��Ʈw���ʡA�ê�^�^���C
4. OpenTelemetry ���Ѿ�����ε{�����|���i�[���ʡC

## �]�w�P�t�m

### ���M����
- .NET 9 SDK
- �㦳 NorthWind ��Ʈw�� SQL Server LocalDB �� SQL Server ���

### ��Ʈw�]�w
�����ε{���ϥ� Entity Framework Core �� Database-First ��k�G

```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet ef dbcontext scaffold "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=NorthWind;Integrated Security=True;..." Microsoft.EntityFrameworkCore.SqlServer -o Models -c NorthWindDbContext
```

### �������ε{��
1. �]�w **Web0720.AppHost** �@���ҰʱM�סC
2. �� F5 �Ұ����ε{���C
3. Aspire ����O�N�|�ҰʡA��ܩҦ��A�Ȫ����A�C

## API ���
Web.API �]�t Swagger UI�A�Ω��s���M���� API ���I�G
- �b�}�o�Ҧ��U�A�i�b Web.API �A�Ȫ��� URL �X�ݡC
- ���ѩҦ� API ���I�����ʦ����C

## ����
- **�椸����**�G��� Web.View.UnitTest �M�פ��C
- **�ݨ�ݴ���**�G��� Web.View.EtoE.TEST �M�פ��C(�|�����) �w�p�ϥ�Playwright

## ����
- �z�Lprompt�覡�A�إߦX�A�q��View������禬�@��Ӭy�{������