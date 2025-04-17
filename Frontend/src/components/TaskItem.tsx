import { Box, Select, Text, VStack, useToast } from "@chakra-ui/react";
import { ProjectTaskResponse, TaskStatus } from "../types/api";
import { useAppDispatch } from "../store/store";
import { updateTask } from "../store/projectsSlice";

export interface TaskItemProps {
  task: ProjectTaskResponse;
  projectId: number;
}

export function TaskItem({ task, projectId }: TaskItemProps) {
  const dispatch = useAppDispatch();
  const toast = useToast();

  const handleStatusChange = async (
    e: React.ChangeEvent<HTMLSelectElement>
  ) => {
    const newStatus = parseInt(e.target.value) as TaskStatus;
    try {
      await dispatch(
        updateTask({
          projectId,
          task: {
            ...task,
            status: newStatus,
            title: task.title ?? "",
            description: task.description ?? "",
          },
        })
      ).unwrap();
      toast({
        title: "Task updated",
        status: "success",
        duration: 3000,
        isClosable: true,
      });
    } catch (err) {
      console.error('Task update failed:', err);
      toast({
        title: "Failed to update task",
        status: "error",
        duration: 3000,
        isClosable: true,
      });
    }
  };

  return (
    <Box p={4} borderWidth={1} borderRadius="md" mb={2}>
      <VStack justify="space-between" align="left">
        <Box>
          <Text fontWeight="bold">{task.title}</Text>
          <Text color="gray.600">{task.description}</Text>
        </Box>
        <Select
          value={task.status}
          onChange={handleStatusChange}
          width="full"
          minW="150px"
        >
          {Object.values(TaskStatus)
            .filter((status) => typeof status === "number")
            .map((status) => (
              <option key={status} value={status}>
                {TaskStatus[status as number]}
              </option>
            ))}
        </Select>
      </VStack>
    </Box>
  );
}
