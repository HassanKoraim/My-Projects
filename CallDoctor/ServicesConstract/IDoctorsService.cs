using ServiceConstracts.DTO;
using ServiceConstracts.Enums;

namespace ServiceConstracts
{
    public interface IDoctorsService
    {
        /// <summary>
        /// Adds a new of Doctor into list of Doctors
        /// </summary>
        /// <param name="doctorAddRequest">Doctor to add</param>
        /// <returns>Returns the same details, with a DoctorId</returns>
        Task<DoctorResponse> AddDoctor(DoctorAddRequest doctorAddRequest);
        /// <summary>
        /// Returns all Doctors
        /// </summary>
        /// <returns>Returns a list of DoctorResponse tybe</returns>
        Task<List<DoctorResponse>> GetAllDoctors();
        /// <summary>
        /// Returns Doctor object based on the given DoctorId
        /// </summary>
        /// <param name="DoctorId">DoctorId to search</param>
        /// <returns>Return Matching Doctor object</returns>
        Task<DoctorResponse>? GetDoctorById(Guid? DoctorId);
        /// <summary>
        /// Returns All matching Doctors based on the search field and search string
        /// </summary>
        /// <param name="searchBy">search field to search</param>
        /// <param name="searchString">search string to search</param>
        /// <returns>Returns All matching Doctors based on the search field and search string</returns>
        Task<List<DoctorResponse>> GetFilteredDoctors(string? searchBy, string? searchString );
        Task<List<DoctorResponse>> GetSortedDoctors(List<DoctorResponse> Alldoctors, string? sortBy, SortOrderOptions sortOrder);
        Task UpdateDoctor();
        Task<bool> DeleteDoctor(Guid id);

    }
}
