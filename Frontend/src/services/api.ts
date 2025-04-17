import type { 
  ProjectResponse, 
  CreateProjectRequest, 
  CreateProjectTaskRequest,
  UpdateProjectTaskRequest,
  ProjectTaskResponse 
} from '../types/api';

const API_URL = 'http://localhost:8080';

const fetcher = async <T>(url: string, config?: RequestInit): Promise<T> => {
  const response = await fetch(`${API_URL}${url}`, config);
  if (!response.ok) {
    throw new Error(`HTTP error! status: ${response.status}`);
  }
  return await response.json() as T;
};

export const getProjects = () => 
  fetcher<ProjectResponse[]>('/Projects');

export const createProject = async (project: CreateProjectRequest): Promise<ProjectResponse> => {
  return fetcher<ProjectResponse>('/Projects', {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
    },
    body: JSON.stringify(project),
  });
};

export const getProjectTasks = async (projectId: number): Promise<ProjectTaskResponse[]> => {
  return await fetcher<ProjectTaskResponse[]>(`/api/projects/${projectId}/ProjectTasks`);
};

export const createProjectTask = (projectId: number, task: CreateProjectTaskRequest) =>
  fetcher<ProjectTaskResponse>(`/api/projects/${projectId}/ProjectTasks`, {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
    },
    body: JSON.stringify(task),
  });

export const updateProjectTask = async (
  projectId: number, 
  task: UpdateProjectTaskRequest
): Promise<ProjectTaskResponse> => {
  const response = await fetch(`${API_URL}/api/projects/${projectId}/ProjectTasks/${task.id}`, {
    method: 'PUT',
    headers: {
      'Content-Type': 'application/json',
    },
    body: JSON.stringify(task),
  });
  
  if (!response.ok) {
    throw new Error(`HTTP error! status: ${response.status}`);
  }
  
  // Handle empty response by returning the original task
  if (response.status === 204 || response.headers.get('content-length') === '0') {
    return { ...task, id: task.id } as ProjectTaskResponse;
  }
  
  return await response.json();
};