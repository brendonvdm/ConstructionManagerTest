import { Box, Button, Heading, VStack } from '@chakra-ui/react';
import { ProjectResponse } from '../types/api';
import { useDispatch } from 'react-redux';
import { fetchProjectTasks, selectProject } from '../store/projectsSlice';
import type { AppDispatch } from '../store/store';

interface ProjectsListProps {
  projects: ProjectResponse[];
  selectedProjectId?: number;
}

export function ProjectsList({ projects, selectedProjectId }: ProjectsListProps) {
  const dispatch = useDispatch<AppDispatch>();
  
  const handleProjectClick = (projectId: number) => {
    dispatch(selectProject(projectId));
    dispatch(fetchProjectTasks(projectId));
  };

  return (
    <Box bg="white" p={6} borderRadius="lg" shadow="md">
      <Heading size="md" mb={4}>Project List</Heading>
      <VStack align="stretch" spacing={2}>
        {projects.map((project) => (
          <Button
            key={project.id}
            onClick={() => handleProjectClick(project.id)}
            variant={selectedProjectId === project.id ? 'solid' : 'ghost'}
            colorScheme={selectedProjectId === project.id ? 'blue' : 'gray'}
            justifyContent="flex-start"
            h="auto"
            py={2}
            whiteSpace="normal"
            textAlign="left"
          >
            {project.name}
          </Button>
        ))}
      </VStack>
    </Box>
  );
}
