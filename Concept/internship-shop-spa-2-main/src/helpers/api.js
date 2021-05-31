import { API_ROUTE } from "../config/api";
import Category from "../models/category";

const ApiClient = {
  get: (url, headers = {}) => {
    return ApiClient.makeRequest(`${API_ROUTE}/${url}`, "GET", {}, headers);
  },
  makeRequest: async (url, type, params = {}, headers = {}) => {
    try {
      type = type.toUpperCase();
      const request = {
        method: type,
        headers: headers,
      };
      if (type === "POST" || type === "PUT") {
        request.body = JSON.stringify(params);
      }

      const result = await fetch(url, request);
      return await result.json();
    } catch (error) {
      throw error.message;
    }
  },
};
const ApiAdmin = {
  post: (url,headers ={}) =>{
    return ApiAdmin.makeRequest(`${API_ROUTE}/${url}`, "POST", {}, headers);
  },
  put: (url,headers ={}) => {
    return ApiAdmin.makeRequest(`${API_ROUTE}/${url}`, "PUT", {}, headers);
  },
  delete: (url,headers ={}) => {
    return ApiAdmin.makeRequest(`${API_ROUTE}/${url}`, "DELETE", {}, headers);
  },
  makeRequest: async (url, type, params = {}, headers = {}) => {
    try {
      type = type.toUpperCase();
      const request = {
        method: type,
        headers: headers,
      };
      if (type === "POST" || type === "PUT") {
        request.body = JSON.stringify(params);
      }

      const result = await fetch(url, request);
      return await result.json();
    } catch (error) {
      throw error.message;
    }
  }
}

const ProductCategories = {
  all: async () => {
    const { categories } = await ApiClient.get("category");
    console.log(categories);
    return categories.map((c) => new Category(c.categoryId, c.name));
  },
};

const ApiHelper = {
  ProductCategories,
};
export default ApiHelper;
