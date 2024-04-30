import {createSlice} from "@reduxjs/toolkit";

export const exampleDataSlice = createSlice({
    name: 'data',
    initialState: {
        value: "",
    },

    reducers: {
        loading: (state) => {
            state.value = "loading";
        },

        loaded: (state, action) => {
            state.value = action.payload;
        },

        error: (state) => {
            state.value = "error";
        }
    }
})

export const { loading,
    loaded,
    error } = exampleDataSlice.actions

export default exampleDataSlice.reducer