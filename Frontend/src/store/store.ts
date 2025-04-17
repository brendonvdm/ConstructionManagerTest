import { configureStore } from '@reduxjs/toolkit';
import { useDispatch } from 'react-redux';
import projectsReducer from './projectsSlice';

export const store = configureStore({
  reducer: {
    projects: projectsReducer,
  },
});

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;

export const useAppDispatch = () => useDispatch<AppDispatch>();