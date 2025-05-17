import { configureStore } from '@reduxjs/toolkit';
import userReducer from './slices/userSlice';
import jobReducer from './slices/jobSlice';
import ResumeReducer from './slices/resumeSlice';

const store = configureStore({
    reducer: {
        user: userReducer,
        job: jobReducer,
        resume: ResumeReducer,
    }, 
});

export type AppDispatch = typeof store.dispatch;
export type RootState = ReturnType<typeof store.getState>;


export default store;