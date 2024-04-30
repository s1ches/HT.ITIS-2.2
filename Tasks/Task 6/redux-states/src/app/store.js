import { configureStore } from '@reduxjs/toolkit'
import exampleDataReducer from '../features/exampleDataSlice'
export default configureStore({
    reducer: {
        exampleData: exampleDataReducer
    },
})