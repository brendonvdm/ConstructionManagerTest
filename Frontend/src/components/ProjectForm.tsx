import { Box, Button, Flex, FormControl, FormLabel, Heading, Input, Stack, Textarea, useToast } from '@chakra-ui/react';
import { CreateProjectRequest } from '../types/api';
import { useDispatch } from 'react-redux';
import { AppDispatch } from '../store/store';
import { createProject } from '../store/projectsSlice';

export interface ProjectFormProps {
  onCancel: () => void;
}

export function ProjectForm({ onCancel }: ProjectFormProps) {
  const dispatch = useDispatch<AppDispatch>();
  const toast = useToast();

  const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    const formData = new FormData(e.currentTarget);
    const project: CreateProjectRequest = {
      name: formData.get('name') as string,
      description: formData.get('description') as string,
    };
    
    try {
      dispatch(createProject(project));
      onCancel();
      toast({
        title: 'Project created',
        status: 'success',
        duration: 3000,
        isClosable: true,
      });
    } catch (error) {
      toast({
        title: 'Failed to create project',
        status: 'error',
        duration: 3000,
        isClosable: true,
      });
    }
  };

  return (
    <Box mb={8} bg="white" p={6} borderRadius="lg" shadow="md">
      <Heading size="md" mb={4}>Create New Project</Heading>
      <form onSubmit={handleSubmit}>
        <Stack spacing={4}>
          <FormControl>
            <FormLabel>Name</FormLabel>
            <Input name="name" required />
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
