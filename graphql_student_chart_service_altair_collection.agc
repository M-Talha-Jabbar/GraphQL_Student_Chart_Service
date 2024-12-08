{"version":1,"type":"collection","title":"GraphQL_Student_Chart_Service","queries":[{"version":1,"type":"window","query":"query {\n  students {\n    id\n    name\n  }\n}\n","apiUrl":"https://localhost:7140/graphql","variables":"{}","subscriptionUrl":"wss://localhost:7140/graphql","subscriptionConnectionParams":"{}","headers":[{"key":"Accept","value":"application/json","enabled":true},{"key":"Content-Type","value":"application/json","enabled":true},{"key":"","value":"","enabled":true}],"windowName":"Retrieve All Students","preRequestScript":"","preRequestScriptEnabled":false,"postRequestScript":"","postRequestScriptEnabled":false,"id":"87daff24-1501-438a-bb62-c990ff561fba","created_at":1732170562911,"updated_at":1732170562911},{"version":1,"type":"window","query":"query {\n  student(id: 5) {\n    id\n    name\n    email\n    phone\n    country\n    dateOfBirth\n    terms\n    courses\n    enrolledYear\n    isWaiverApplicable\n    vPDI\n  }\n}\n","apiUrl":"https://localhost:7140/graphql","variables":"{}","subscriptionUrl":"wss://localhost:7140/graphql","subscriptionConnectionParams":"{}","headers":[{"key":"Accept","value":"application/json","enabled":true},{"key":"Content-Type","value":"application/json","enabled":true},{"key":"","value":"","enabled":true}],"windowName":"Retrieve a Student by ID","preRequestScript":"","preRequestScriptEnabled":false,"postRequestScript":"","postRequestScriptEnabled":false,"id":"c6ae3429-3df9-41ed-aa4a-a7ff47ea57a5","created_at":1732170562911,"updated_at":1732170562911},{"version":1,"type":"window","query":"query {\n  studentsByEnrolledYear(year: 2005) {\n    id\n    name\n    email\n    phone\n    country\n    enrolledYear\n    isWaiverApplicable\n    vPDI\n  }\n}","apiUrl":"https://localhost:7140/graphql","variables":"{}","subscriptionUrl":"wss://localhost:7140/graphql","subscriptionConnectionParams":"{}","headers":[{"key":"Accept","value":"application/json","enabled":true},{"key":"Content-Type","value":"application/json","enabled":true},{"key":"","value":"","enabled":true}],"windowName":"Retrieve Students by Enrolled Year","preRequestScript":"","preRequestScriptEnabled":false,"postRequestScript":"","postRequestScriptEnabled":false,"id":"1027b490-e957-49e6-ad23-13a22a61d000","created_at":1732170562911,"updated_at":1732170562911},{"version":1,"type":"window","query":"query {\n  studentsWithWaiver {\n    id\n    name\n    enrolledYear\n  }\n}\n","apiUrl":"https://localhost:7140/graphql","variables":"{}","subscriptionUrl":"wss://localhost:7140/graphql","subscriptionConnectionParams":"{}","headers":[{"key":"Accept","value":"application/json","enabled":true},{"key":"Content-Type","value":"application/json","enabled":true},{"key":"","value":"","enabled":true}],"windowName":"Retrieve Students Eligible for Waivers","preRequestScript":"","preRequestScriptEnabled":false,"postRequestScript":"","postRequestScriptEnabled":false,"id":"0aa25758-6e5c-4f9d-ad79-90e9f3df92ca","created_at":1732170562911,"updated_at":1732170562911},{"version":1,"type":"window","query":"query {\n  totalStudents\n}\n","apiUrl":"https://localhost:7140/graphql","variables":"{}","subscriptionUrl":"wss://localhost:7140/graphql","subscriptionConnectionParams":"{}","headers":[{"key":"Accept","value":"application/json","enabled":true},{"key":"Content-Type","value":"application/json","enabled":true},{"key":"","value":"","enabled":true}],"windowName":"Get Total Student Count","preRequestScript":"","preRequestScriptEnabled":false,"postRequestScript":"","postRequestScriptEnabled":false,"id":"0c7bab33-3114-4d30-83c1-8458ab34ca08","created_at":1732170562911,"updated_at":1732170562911},{"version":1,"type":"window","query":"query {\n  studentsByCountry(country: \"Germany\") {\n    id\n    name\n    email\n    phone\n    country\n    enrolledYear\n    isWaiverApplicable\n    vPDI\n  }\n}","apiUrl":"https://localhost:7140/graphql","variables":"{}","subscriptionUrl":"wss://localhost:7140/graphql","subscriptionConnectionParams":"{}","headers":[{"key":"Accept","value":"application/json","enabled":true},{"key":"Content-Type","value":"application/json","enabled":true},{"key":"","value":"","enabled":true}],"windowName":"Retrieve Students by Country","preRequestScript":"","preRequestScriptEnabled":false,"postRequestScript":"","postRequestScriptEnabled":false,"id":"a60d4196-3e89-4d67-b996-b5e16d9f065b","created_at":1732170562911,"updated_at":1732170562911},{"version":1,"type":"window","query":"query {\n  waiverCountByYear(year: 2005) {\n    withWaiver\n    withoutWaiver\n  }\n}","apiUrl":"https://localhost:7140/graphql","variables":"{}","subscriptionUrl":"wss://localhost:7140/graphql","subscriptionConnectionParams":"{}","headers":[{"key":"Accept","value":"application/json","enabled":true},{"key":"Content-Type","value":"application/json","enabled":true},{"key":"","value":"","enabled":true}],"windowName":"Waiver Count by Year","preRequestScript":"","preRequestScriptEnabled":false,"postRequestScript":"","postRequestScriptEnabled":false,"id":"c6c475bf-ebdf-4dae-ab18-65ac7e76030b","created_at":1732170562911,"updated_at":1732170562911},{"version":1,"type":"window","query":"query {\n  studentCountByYear(year: 2006) {\n    national\n    international\n  }\n}","apiUrl":"https://localhost:7140/graphql","variables":"{}","subscriptionUrl":"wss://localhost:7140/graphql","subscriptionConnectionParams":"{}","headers":[{"key":"Accept","value":"application/json","enabled":true},{"key":"Content-Type","value":"application/json","enabled":true},{"key":"","value":"","enabled":true}],"windowName":"Student Count by Year","preRequestScript":"","preRequestScriptEnabled":false,"postRequestScript":"","postRequestScriptEnabled":false,"id":"d7e5e1fb-987f-4df4-b80f-83438fbd9b73","created_at":1732170562911,"updated_at":1732170562911},{"version":1,"type":"window","query":"query {\n  totalStudents\n  \n  studentsByEnrolledYear(year: 2005) {\n    id\n    name\n    email\n  }\n\n  studentsByCountry(country: \"Germany\") {\n    id\n    name\n    email\n  }\n}\n","apiUrl":"https://localhost:7140/graphql","variables":"{}","subscriptionUrl":"wss://localhost:7140/graphql","subscriptionConnectionParams":"{}","headers":[{"key":"Accept","value":"application/json","enabled":true},{"key":"Content-Type","value":"application/json","enabled":true},{"key":"","value":"","enabled":true}],"windowName":"Combining Multiple Queries","preRequestScript":"","preRequestScriptEnabled":false,"postRequestScript":"","postRequestScriptEnabled":false,"id":"40a4745c-5a99-4190-b665-275f6cc34477","created_at":1732170562911,"updated_at":1732170562911},{"version":1,"type":"window","query":"mutation {\n  createStudent(\n    name: \"John Doe\"\n    email: \"john.doe@example.com\"\n    phone: \"1234567890\"\n    country: \"USA\"\n    dateOfBirth: \"2000-01-01\"\n    terms: [\"Fall 2023\", \"Spring 2024\"]\n    courses: [\"Math\", \"Science\"]\n    enrolledYear: 2023\n    isWaiverApplicable: true\n    vPDI: \"TTU\"\n  ) {\n    id\n    name\n    email\n    phone\n    terms\n    courses\n    enrolledYear\n    isWaiverApplicable\n    vPDI\n  }\n}\n","apiUrl":"https://localhost:7140/graphql","variables":"{}","subscriptionUrl":"wss://localhost:7140/graphql","subscriptionConnectionParams":"{}","headers":[{"key":"Accept","value":"application/json","enabled":true},{"key":"Content-Type","value":"application/json","enabled":true},{"key":"","value":"","enabled":true}],"windowName":"Create a New Student","preRequestScript":"","preRequestScriptEnabled":false,"postRequestScript":"","postRequestScriptEnabled":false,"id":"8c174cd7-954b-48b8-87ab-2d3aec527090","created_at":1732170562911,"updated_at":1732170562911},{"version":1,"type":"window","query":"mutation {\n  login(username: \"admin\", password: \"admin123\") {\n    username\n    token\n  }\n}\n","apiUrl":"https://localhost:7140/graphql","variables":"{}","subscriptionUrl":"wss://localhost:7140/graphql","subscriptionConnectionParams":"{}","headers":[{"key":"Accept","value":"application/json","enabled":true},{"key":"Content-Type","value":"application/json","enabled":true},{"key":"","value":"","enabled":true}],"windowName":"Login","preRequestScript":"","preRequestScriptEnabled":false,"postRequestScript":"","postRequestScriptEnabled":false,"id":"c19dc416-a6ce-478b-9194-0a9a09288ec7","created_at":1732170562911,"updated_at":1732170562911},{"version":1,"type":"window","query":"query {\n  filteredStudents(country: \"Germany\", enrolledYear: 2006, isWaiverApplicable: true) {\n    id\n    name\n    email\n    phone\n    country\n    dateOfBirth\n    terms\n    courses\n    enrolledYear\n    isWaiverApplicable\n    vPDI\n  }\n}","apiUrl":"https://localhost:7140/graphql","variables":"{}","subscriptionUrl":"wss://localhost:7140/graphql","subscriptionConnectionParams":"{}","headers":[{"key":"Accept","value":"application/json","enabled":true},{"key":"Content-Type","value":"application/json","enabled":true},{"key":"","value":"","enabled":true}],"windowName":"Filtered Students","preRequestScript":"","preRequestScriptEnabled":false,"postRequestScript":"","postRequestScriptEnabled":false,"id":"861567b7-1713-4d32-8623-ee15ffa88b0e","created_at":1732170562911,"updated_at":1732170562911}],"preRequest":{"script":"","enabled":false},"postRequest":{"script":"","enabled":false},"id":"5d2e1fb7-b9ac-498f-8ead-82b04d4b34d3","parentPath":"","created_at":1732170562911,"updated_at":1732170562911,"collections":[]}