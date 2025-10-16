using firstAPI.model;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;



namespace firstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalmanController : ControllerBase
    {
        public string _connection;
        private readonly IHttpClientFactory _httpClientFactory;
        public SalmanController(IConfiguration conig,IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _connection = conig.GetConnectionString("Salman");
        }
        [HttpPost("ValidUser")]
        public ActionResult<IDictionary<string, object>> ValidUser(ValidUser validUser) 
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connection))
            {
                sqlConnection.Open();
                using (SqlCommand cmd = new SqlCommand("LoginUser", sqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserName", validUser.UserName);
                    cmd.Parameters.AddWithValue("@Password", validUser.Password);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        var result = new List<Dictionary<string, object>>();
                        while (reader.Read())
                        {
                            var row = new Dictionary<string, object>();
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                row[reader.GetName(i)] = reader.IsDBNull(i) ? null : reader.GetValue(i);
                            }
                            result.Add(row);
                        }
                        return Ok(result); // Return HTTP 200 with the data
                    }
                }
            }



        }
        [HttpGet("usp_GetDropdowuns")]
        public ActionResult<IDictionary<string, object>> usp_GetDropdowuns()
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connection))
            {
                sqlConnection.Open();
                using (SqlCommand cmd = new SqlCommand("usp_GetDropdowns", sqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        var result = new List<Dictionary<string, object>>();
                        while (reader.Read())
                        {
                            var row = new Dictionary<string, object>();
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                row[reader.GetName(i)] = reader.IsDBNull(i) ? null : reader.GetValue(i);
                            }
                            result.Add(row);
                        }
                        return Ok(result); // Return HTTP 200 with the data
                    }
                }
            }
        }
        [HttpPost("brands")]
        public ActionResult<List<IDictionary<string, object>>> GetBrands(Brand brand)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connection))
            {
                sqlConnection.Open();
                using (SqlCommand cmd = new SqlCommand("usp_Brands_CRUD", sqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Flag", brand.Flag);
                    cmd.Parameters.AddWithValue("@BrandID", brand.BrandID ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Name", brand.Name ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Description", brand.Description ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Website", brand.Website ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ContactEmail", brand.ContactEmail ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ContactPhone", brand.ContactPhone ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Active", brand.Active ?? (object)DBNull.Value);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        var result = new List<Dictionary<string, object>>();
                        while (reader.Read())
                        {
                            var row = new Dictionary<string, object>();
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                row[reader.GetName(i)] = reader.IsDBNull(i) ? null : reader.GetValue(i);
                            }
                            result.Add(row);
                        }
                        return Ok(result);
                    }
                }
            }
        }
        [HttpPost("categories")]
        public ActionResult<List<IDictionary<string, object>>> GetCategories(Category category)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connection))
            {
                sqlConnection.Open();
                using (SqlCommand cmd = new SqlCommand("usp_Categories_CRUD", sqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Flag", category.Flag);
                    cmd.Parameters.AddWithValue("@CategoryID", category.CategoryID);
                    cmd.Parameters.AddWithValue("@Name", category.Name);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        var result = new List<Dictionary<string, object>>();
                        while (reader.Read())
                        {
                            var row = new Dictionary<string, object>();
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                row[reader.GetName(i)] = reader.IsDBNull(i) ? null : reader.GetValue(i);
                            }
                            result.Add(row);
                        }
                        return Ok(result);
                    }
                }
            }
        }
        [HttpPost("sizes")]
        public ActionResult<List<IDictionary<string, object>>> GetSizes(Size size)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connection))
            {
                sqlConnection.Open();
                using (SqlCommand cmd = new SqlCommand("usp_Sizes_CRUD", sqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Flag", size.Flag);
                    cmd.Parameters.AddWithValue("@SizeID", size.SizeID);
                    cmd.Parameters.AddWithValue("@Name", size.Name);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        var result = new List<Dictionary<string, object>>();
                        while (reader.Read())
                        {
                            var row = new Dictionary<string, object>();
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                row[reader.GetName(i)] = reader.IsDBNull(i) ? null : reader.GetValue(i);
                            }
                            result.Add(row);
                        }
                        return Ok(result);
                    }
                }
            }
        }
        [HttpPost("suppliers")]
        public ActionResult<List<IDictionary<string, object>>> SupplierAction([FromBody] Supplier model)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connection))
            {
                sqlConnection.Open();
                using (SqlCommand cmd = new SqlCommand("usp_Suppliers_CRUD", sqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Flag", model.Flag ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@SupplierID", model.SupplierID ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Name", model.Name ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ContactName", model.ContactName ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Phone", model.Phone ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Email", model.Email ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Address", model.Address ?? (object)DBNull.Value);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        var result = new List<Dictionary<string, object>>();
                        while (reader.Read())
                        {
                            var row = new Dictionary<string, object>();
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                row[reader.GetName(i)] = reader.IsDBNull(i) ? null : reader.GetValue(i);
                            }
                            result.Add(row);
                        }
                        return Ok(result);
                    }
                }
            }
        }
        [HttpPost("colors")]
        public ActionResult<List<IDictionary<string, object>>> ColorsAction([FromBody] Color model)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connection))
            {
                sqlConnection.Open();
                using (SqlCommand cmd = new SqlCommand("usp_Colors_CRUD", sqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Flag", model.Flag ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ColorID", model.ColorID ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Name", model.Name ?? (object)DBNull.Value);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        var result = new List<Dictionary<string, object>>();
                        while (reader.Read())
                        {
                            var row = new Dictionary<string, object>();
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                row[reader.GetName(i)] = reader.IsDBNull(i) ? null : reader.GetValue(i);
                            }
                            result.Add(row);
                        }
                        return Ok(result);
                    }
                }
            }
        }
        [HttpPost("products")]
        public ActionResult<List<IDictionary<string, object>>> ProductsAction([FromBody] Product model)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connection))
            {
                sqlConnection.Open();
                using (SqlCommand cmd = new SqlCommand("usp_Products_CRUD", sqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Flag", (object)model.Flag ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ProductID", (object)model.ProductID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@SKU", (object)model.SKU ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Name", (object)model.Name ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Description", (object)model.Description ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@BrandID", (object)model.BrandID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CategoryID", (object)model.CategoryID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@SizeID", (object)model.SizeID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ColorID", (object)model.ColorID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@SupplierID", (object)model.SupplierID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@PurchasePrice", (object)model.PurchasePrice ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@SalePrice", (object)model.SalePrice ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ReorderLevel", (object)model.ReorderLevel ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsActive", (object)model.IsActive ?? DBNull.Value);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        var result = new List<Dictionary<string, object>>();
                        while (reader.Read())
                        {
                            var row = new Dictionary<string, object>();
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                row[reader.GetName(i)] = reader.IsDBNull(i) ? null : reader.GetValue(i);
                            }
                            result.Add(row);
                        }
                        return Ok(result);
                    }
                }
            }
        }

        [HttpPost("Customers")]
        public IActionResult ManageCustomer([FromBody] Customer request)
        {
            var customers = new List<Customer>();

            using (SqlConnection conn = new SqlConnection(_connection))
            using (SqlCommand cmd = new SqlCommand("dbo.usp_Customers_CRUD", conn))
            {
                conn.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Flag", request.Flag);
                cmd.Parameters.AddWithValue("@CustomerID", (object?)request.CustomerID ?? DBNull.Value); cmd.Parameters.AddWithValue("@Name", request.Name ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Phone", request.Phone ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Email", request.Email ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Address", request.Address ?? (object)DBNull.Value);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    var result = new List<Dictionary<string, object>>();
                    while (reader.Read())
                    {
                        var row = new Dictionary<string, object>();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            row[reader.GetName(i)] = reader.IsDBNull(i) ? null : reader.GetValue(i);
                        }
                        result.Add(row);
                    }
                    return Ok(result);
                }
            }
        }

        [AllowAnonymous] // Key: allows requests without auth!
        [HttpPost("SendImage")]
        public async Task<IActionResult> SendBillImage([FromBody] WhatsappImageRequest request)
        {
            var phoneNumberId = "8332906833"; // your business phone number ID
            var accessToken = "6e9e7209e2eb64715b23044533cc3aff"; // your WhatsApp API access token
            var apiUrl = $"https://graph.facebook.com/v18.0/{phoneNumberId}/messages";

            var body = new
            {
                messaging_product = "whatsapp",
                to = request.RecipientNumber,
                type = "image",
                image = new { link = request.ImageUrl }
            };
            var client = _httpClientFactory.CreateClient();
            var content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");

            var response = await client.PostAsync(apiUrl, content);
            var result = await response.Content.ReadAsStringAsync();

            // Always return valid JSON!
            if (response.IsSuccessStatusCode)
                return Ok(new { success = true, result });

            return StatusCode((int)response.StatusCode, new { success = false, result });
        }
    }
}

