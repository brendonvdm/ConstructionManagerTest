import { Box, Button, Flex, FormControl, FormLabel, Heading, Input, Stack, Textarea } from '@chakra-ui/react';
import { CreateProjectTaskRequest, TaskStatus } from '../types/api';
import { useToast } from '@chakra-ui/react';
import { useAppDispatch } from '../store/store';
import { createTask } from '../store/projectsSlice';

export interface TaskFormProps {
  projectId: number;
  onCancel: () => void;
  onSuccess?: () => void;
}

export function TaskForm({ projectId, onCancel, onSuccess }: TaskFormProps) {
  const dispatch = useAppDispatch();
  const toast = useToast();

  const handleCreateTask = async (task: Omit<CreateProjectTaskRequest, "status" | "projectId">) => {
    try {
      await dispatch(createTask({ 
        projectId, 
        task: { 
          ...task, 
          status: TaskStatus.Todo,
          projectId
        }
      }));
      toast({
        title: 'Task created',
        status: 'success',
        duration: 3000,
        isClosable: true,
      });
      onSuccess?.();
    } catch (error) {
      toast({
        title: 'Failed to create task',
        status: 'error',
        duration: 3000,
        isClosable: true,
      });
    }
  };

  const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    const formData = new FormData(e.currentTarget);
    const task = {
      title: formData.get('title') as string,
      description: formData.get('description') as string,
    };
    await handleCreateTask(task);
  };

  return (
    <Box mb={6} bg="white" p={6} borderRadius="lg" shadow="md">
      <Heading size="md" mb={4}>Create New Task</Heading>
      <form onSubmit={handleSubmit}>
        <Stack spacing={4}>
          <FormControl>
            <FormLabel>Title</FormLabel>
            <Input name="title" required />
          </FormControl>
          <FormControl>
            <FormLabel>Description</FormLabel>
            <Textarea name="description" rows={3} />
          </FormControl>
          <Flex justify="flex-end" gap={2}>
            <Button onClick={onCancel}>Cancel</Button>
            <Button type="submit" colorScheme="blue">Create</Button>
          </Flex>
        </Stack>
      </form>
    </Box>
  );
}
