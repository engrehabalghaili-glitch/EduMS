using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M4_AssetLogistics;

public interface IAssetFeasibilityRiskAnalysisRepository : IGenericRepository<AssetFeasibilityRiskAnalysis>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب تحليلات المخاطر بناءً على التوصية النهائية (شراء، رفض، تأجيل، بديل)
    Task<IEnumerable<AssetFeasibilityRiskAnalysis>> GetAnalysesByRecommendationAsync(int finalRecommendation, CancellationToken cancellationToken = default);
    
    // جلب التحليلات بناءً على مستوى المخاطرة (منخفض، متوسط، عالي)
    Task<IEnumerable<AssetFeasibilityRiskAnalysis>> GetAnalysesByRiskLevelAsync(int riskLevel, CancellationToken cancellationToken = default);
    
    // جلب التحليلات المعتمدة
    Task<IEnumerable<AssetFeasibilityRiskAnalysis>> GetApprovedAnalysesAsync(CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب التحليلات الخاصة بمدرسة محددة
    Task<IEnumerable<AssetFeasibilityRiskAnalysis>> GetAnalysesBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
    
    // جلب تحليل المخاطر المرتبط بطلب احتياج معين
    Task<AssetFeasibilityRiskAnalysis?> GetAnalysisByRequirementRequestIdAsync(long requirementRequestId, CancellationToken cancellationToken = default);
}
