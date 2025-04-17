import { createSlice, createAsyncThunk, PayloadAction } from '@reduxjs/toolkit';
import * as api from '../services/api';
import type { ProjectResponse, ProjectTaskResponse, CreateProjectRequest, CreateProjectTaskRequest, UpdateProjectTaskRequest } from '../types/api';

interface ProjectsState {
  projects: ProjectResponse[];
  projectTasks: Record<number, ProjectTaskResponse[]>;
  selectedProject: number | null;
  loading: boolean;
  error: string | null;
}

const initialState: ProjectsState = {
  projects: [],
  projectTasks: [],
  selectedProject: null,
  loading: false,
  error: null,
};

export const fetchProjects = createAsyncThunk(
  'projects/fetchProjects',
  async () => {
    return await api.getProjects();
  }
);

export const fetchProjectTasks = createAsyncThunk(
  'projects/fetchProjectTasks',
  async (projectId: number) => {
    return await api.getProjectTasks(projectId);
  }
);

export const createProject = createAsyncThunk(
  'projects/createProject',
  async (project: CreateProjectRequest) => {
    return await api.createProject(project);
  }
);

export const createTask = createAsyncThunk(
  'projects/createTask',
  async ({ projectId, task }: { projectId: number; task: CreateProjectTaskRequest }) => {
    return await api.createProjectTask(projectId, task);
  }
);

export const updateTask = createAsyncThunk(
  'projects/updateTask',
  async ({ projectId, task }: { projectId: number; task: UpdateProjectTaskRequest }) => {
    console.log('Updating task via API', { projectId, task });
    const updatedTask = await api.updateProjectTask(projectId, task);
    console.log('API response:', updatedTask);
    return { projectId, task: updatedTask };
  }
);

const projectsSlice = createSlice({
  name: 'projects',
  initialState,
  reducers: {
    selectProject: (state, action: PayloadAction<number | null>) => {
      state.selectedProject = action.payload;
    }
  },
  extraReducers: (builder) => {
    builder
      .addCase(fetchProjects.pending, (state) => {
        state.loading = true;
        state.error = null;
      })
      .addCase(fetchProjects.fulfilled, (state, action) => {
        state.loading = false;
        state.projects = action.payload;
      })
      .addCase(fetchProjects.rejected, (state, action) => {
        state.loading = false;
        state.error = action.error.message || 'Failed to fetch projects';
      })
      .addCase(fetchProjectTasks.fulfilled, (state, action) => {
        state.projectTasks[action.meta.arg] = action.payload;
      })
      .addCase(createProject.fulfilled, (state, action) => {
        state.projects.push(action.payload);
      })
      .addCase(createTask.fulfilled, (state, action) => {
        const { projectId } = action.meta.arg;
        if (state.projectTasks[projectId]) {
          state.projectTasks[projectId].push(action.payload);
        } else {
          state.projectTasks[projectId] = [action.payload];
        }
      })
      .addCase(updateTask.fulfilled, (state, action) => {
        console.log('Updating state with:', action.payload);
        const { projectId, task } = action.payload;
        if (state.projectTasks[projectId]) {
          state.projectTasks[projectId] = state.projectTasks[projectId].map(t => 
            t.id === task.id ? task : t
          );
        }
      });
  },
});

export const { selectProject } = projectsSlice.actions;
export default projectsSlice.reducer;