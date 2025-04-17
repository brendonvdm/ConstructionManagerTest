import {
  Box,
  Button,
  Flex,
  Heading,
  Text
} from "@chakra-ui/react";
import { Plus } from "lucide-react";
import { ProjectResponse, ProjectTaskResponse, TaskStatus } from "../types/api";
import { TaskItem } from "./TaskItem";
import { TaskForm } from "./TaskForm";
import { useState } from "react";
import { useSelector } from 'react-redux';
import type { RootState } from '../store/store';

export interface ProjectDetailsProps {
  project: ProjectResponse | null;
}

export function ProjectDetails({ project }: ProjectDetailsProps) {

  const [showTaskForm, setShowTaskForm] = useState(false);
  const tasks = useSelector((state: RootState) => state.projects.projectTasks[project?.id ?? -1] || []);

  return (
    <Box bg="white" p={6} borderRadius="lg" shadow="md">
      <Flex justify="space-between" align="center" mb={6}>
        <Heading size="lg">{project?.name}</Heading>
        <Button
          leftIcon={<Plus size={20} />}
          colorScheme="blue"
          onClick={() => setShowTaskForm(true)}
        >
          New Task
        </Button>
      </Flex>

      <Text mb={6}>{project?.description}</Text>

      {showTaskForm && (
        <TaskForm 
          projectId={project?.id ?? -1} 
          onCancel={() => setShowTaskForm(false)}
          onSuccess={() => setShowTaskForm(false)}
        />
      )}
      <Flex wrap="wrap" align="stretch" justify="stretch" gap={4}>
        {[TaskStatus.Todo, TaskStatus.InProgress, TaskStatus.Done].map(
          (status) => (
            <Flex key={status} direction="column" align="stretch" flex={1}>
              <Heading size="sm" m={2}>{TaskStatus[status]}</Heading>
              {tasks
                .filter((task: { status: TaskStatus; }) => task.status === status)
                .map((task: ProjectTaskResponse) => (
                  <TaskItem 
                    key={task.id} 
                    task={task} 
                    projectId={project?.id ?? -1}
                  />
                ))}
            </Flex>
          )
        )}
      </Flex>
    </Box>
  );
}
