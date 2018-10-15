const signUpRules = {
    "user-name": [
      {
        isValid(value: string, inputs: any, funcs: any) {
          return value.length !== 0;
        },
        errorMessage: "Field required."
      },
      {
        isValid(value: string, inputs: any, funcs: any) {
          return value.length >= 8;
        },
        errorMessage: "Name must be between 8-20 characters."
      },
      {
        isValid(value: string, inputs: any, funcs: any) {
          return value.length <= 20;
        },
          errorMessage: "Name must be between 8-20 characters."
      }
    ],
    "user-email": [
      {
        isValid(value: string, inputs: any, funcs: any) {
          return value.length !== 0;
        },
        errorMessage: "Field required."
      },
      {
        isValid(value: string, inputs: any, funcs: any) {
          const reg = /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$/gi;
  
          return reg.test(value);
        },
        errorMessage: "Email format is invalid."
      }
    ],
    "user-password": [
      {
        isValid(value: string, inputs: any, funcs: any) {
          return value.length !== 0;
        },
        errorMessage: "Field required."
      },
      {
        isValid(value: string, inputs: any, funcs: any) {
          return value.length >= 6;
        },
        errorMessage: "Password must be between 6-20 characters."
      },
      {
        isValid(value: string, inputs: any, funcs: any) {
          return value.length <= 20;
        },
          errorMessage: "Password must be between 6-20 characters."
      }
    ],
    "user-confpass": [
      {
        isValid(value: string, inputs: any, funcs: any) {
          return value.length !== 0;
        },
        errorMessage: "Field required."
      },
      {
        isValid(value: string, inputs: any, funcs: any) {
          const passIndex = funcs.getItemById("user-confpass", inputs).index;
          const duplicatePassIndex = funcs.getItemById("user-password", inputs)
            .index;
  
          return inputs[passIndex].value === inputs[duplicatePassIndex].value;
        },
        errorMessage: "Passwords do not match."
      }
    ]
  };
  
  const loginRules = {
    "user-email": [
       {
          isValid(value: string, inputs: any, funcs: any) {
             return value.length !== 0;
          },
          errorMessage: "Field required."
       },
       {
          isValid(value: string, inputs: any, funcs: any) {
             const reg = /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$/gi;
 
             return reg.test(value);
 
          },
          errorMessage: "Email format is invalid."
       }
    ],
    "user-password": [
      {
        isValid(value: string, inputs: any, funcs: any) {
          return value.length !== 0;
        },
        errorMessage: "Field required."
      },
      {
        isValid(value: string, inputs: any, funcs: any) {
          return value.length >= 6;
        },
        errorMessage: "Password must be between 6-20 characters."
      },
      {
        isValid(value: string, inputs: any, funcs: any) {
          return value.length <= 20;
        },
          errorMessage: "Password must be between 6-20 characters."
      }
    ]
 }
 
 
  
  const changeRule = {
      "password": [
         {
            isValid(value: string, inputs: any, funcs: any) {
               return value.length !== 0;
            },
            errorMessage: "Field required"
         },
         {
            isValid(value: string, inputs: any, funcs: any) {
               return value.length > 6;
            },
             errorMessage: "Password must be between 6-20 characters."
         },
         {
            isValid(value: string, inputs: any, funcs: any) {
               return value.length < 20;
            },
             errorMessage: "Password must be between 6-20 characters."
         }
      ],
      "confirm-password": [
         {
            isValid(value: string, inputs: any, funcs: any) {
               return value.length !== 0;
            },
            errorMessage: "Field required"
         },
         {
            isValid(value: string, inputs: any, funcs: any) {
               const passIndex = funcs.getItemById("confirm-password", inputs).index;
               const duplicatePassIndex = funcs.getItemById("password", inputs).index;
   
               return inputs[passIndex].value === inputs[duplicatePassIndex].value;
   
            },
            errorMessage: "Passwords do not match."
         }
      ]
   };
  
  export { signUpRules, loginRules, changeRule};